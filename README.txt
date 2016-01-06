iTunes Artwork Export
---------------------

https://github.com/BrianMulholland/itunes-artwork-export

iTunes Artwork Export is designed to iterate through the music in your iTunes library, and
export the cover art for each album to a file in the corresponding folder (such as
"folder.jpg").  This is useful if something is scanning your music library and using that
file to display artwork for each album - for example, a Sonos system.  This is a Windows
application, built using the .NET framework.

Written by: Brian Mulholland (twitter.com/brianmulholland)
Copyright 2013-present (GNU GPL v3)

iTunes is a registered trademark of Apple, Inc.


Version History:
----------------

Version 0.4 (1/6/16):
- Added settings functionality (issue #5)
- Added ability to export the main text window to a file (issue #7)
- Added alert when processing is finished (issue #8)
- Minor tweaks to setup project and the main form; various other code cleanups
- As a result of the move from Google Code to GitHub, I also had to move from Mercurial to
  Git.  Removed Mercurial .hgignore file, added new .gitignore file; expanded the ignore list.
- Added this readme.txt file

Version 0.3 (11/2/14):
- Major change to put the processing within a BackgroundWorker, which keeps the UI responsive
  during the export (issue #2)
- Added progress bar (issue #3)
- Now scrolls to the bottom of the main text box whenever a new message is added (issue #6)
- Added a Cancel button
- Various other minor changes

Version 0.2 (11/13/13):
- Added setup project
- Minor changes to solution

Version 0.1 (10/30/13):
- Initial version
