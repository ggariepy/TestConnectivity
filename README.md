# TestConnectivity
Windows based file share connectivity tester

DATE: 22-AUG-2018
AUTHOR: Geoff Gariepy
	geoff.gariepy@gmail.com

I wrote this little connectivity checker console app called TestConnectivity.exe that attempts to connect to a remote directory share thousands of times and list out its files.

The idea was that with repetition I might uncover an Active Directory glitch in my company's crummy environment after thousands of attempts.

If there is an error, the program catches the exception and outputs how many times it tried the connection before it failed, and the message from the failure.

So far that idea has failed to pan out in my case with useful diagnostic info, but the utility might be useful anyway to someone else.

	Usage:

	TestConnectivity.exe [repetitions] [path] [file pattern]

	Example:

	TestConnectivity.exe 1000 \\someserver\somepath\ *.silly  -- checks \\someserver\somepath\ for the existence of *.silly files 1,000 times.

	Note:

	The app has pretty stupid parameter handling.  It will substitute in default values if you leave one or more of them off, but if
	you do include values, make sure they're in the correct position, otherwise you'll be scanning weird server names and the like.

Here's a successful sample run with some silly file names:

C:\TestConnectivity>TestConnectivity.exe 100000 \\server\share *.silly
---
Testing connectivity to \\server\share 100000 times for files of type [*.silly]
Finished 100000 tests for files of type *.silly.
Found file: \\server\share\bad.silly
Found file: \\\server\share\dumb.silly
Found file: \\server\share\good.silly
Found file: \\server\share\iwanna.silly

Here's a failed sample run where the process couldn't connect to the remote server:
---
C:\TestConnectivity>TestConnectivity.exe 100000 \\server\bogusshare *.silly
Testing connectivity to \\server\bogusshare 100000 times files of type [*.silly]
Failed after iteration #0 with error The network name cannot be found.

Here's a successful sample run where it didn't find any files (but didn't encounter any errors)
---
C:\TestConnectivity>TestConnectivity.exe 1000 \\server\share *.silly
Testing connectivity to \\server\share 1000 times for files of type [*.silly]
Finished 1000 tests for files of type [*.silly]
Did not find any [*.silly] files at this time.

I recommend using it under the context of the user ID that does the file check in production.  A handy way to accomplish this is the runas command.  Example:

	C:\Users\someuser>runas /user:DOMAIN\USER cmd.exe
	Enter the password for DOMAIN\USER:
	Attempting to start cmd.exe as user "DOMAIN\USER" ...

You will then be given a new cmd window that you can use to execute TestConnectivity.exe within.

License:
--------
Use and abuse this as you will.  If you simply find it useful, send a few bucks to the email address above via Paypal and I'll drink a beer to your success.

If you modify the code and make it better, fantastic.  Please do share, and credit me in your readme.txt file.

If you just want to say hello or make suggestions, email me.  Suggestions that come with dollar signs attached tend to get my attention.  

If any use of this program or your derivative thereof makes/saves you more than US $100, I get 10% up to US $1,000.  Anything more than that: we need to talk terms.
