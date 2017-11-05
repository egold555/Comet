# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/).

## [1.0.0] - 11/4/2017
### Changed
 - Name from Vixen+ to Comet

### Added
 - 

---------



<br>

# Vixen+ ChangeLog
------

NOTE: For items prefixed with VIX-, you can view more details on https://vixenplus.atlassian.net

 1 DEC 2015 - V 0.3.333.83
     VIX-63 - Bug in export of fseq would cause crash if you didn't have an audio file associated.

17 NOV 2015 - V 0.3.319.1
    NO JIRA - Identified an fixed update issue.
    NO JIRA - Add is enabled when select or add is chosen in the profile drop down.  

06 NOV 2015 - V 0.3.308.1
  NO JIRA   - SaveAs... now supports Falcon Player Sequence (.fseq)

04 May 2015 - V 0.3.180.1
  NO JIRA   - Regression issue on E1.31 plug, added buttons back in.
  NO JIRA   - Misc bug fixes.

24 FEB 2015 - V 0.3.55.1
  VIX-58    - Found a bug when a user reported issues with the channel mapper.  If you selected "Map Unmapped Source Channels"
              it would map channels already mapped, causing an error. - FIXED
Ernie-027   - Fixed the annoying crash when a profile was missing, added a retry option with the file name shown so you can move
              the profile into the proper place.

23 FEB 2015 - V 0.3.54.1
  VIX-60    - Groups not saving properly and save button not changing when a change to the group is made. - Fixed
  NO JIRA   - Added Emmanuel Miranda to the credits for the RGB Mega Tree 3D Preview.
  NOTE      - From last version forward, Adjustable Preview and RGB Mega Tree 3d Preview are not constrained to the Vixen+
              parent window and they can control playback using the F keys as well.

20 FEB 2015 - V 0.3.51.1
  Fixed a lot of annoyances in Roadie - much more stable and reliable.  Drag and drop renumbering works well.
  Link to our favorite Lutefisk recipes.
  LOR lms files can be loaded. Ready to add more file types but I need files for testing.
  Cleaned up E1.31 plugin, I didn't realize I was missing some stuff.
  Lots of stuff done on the inside that you don't see, but I have to look at every day! :D

26 JAN 2015 - V 0.3.26.1
  NO JIRA   - Fixed the automated build process which was missing the new dll.

25 JAN 2015 - V 0.3.25.1
  VIX-55    - Adding a new profile crashes because the file handler is null.
  VIX-48    - Show the current data folder on the preferences screen.

24 JAN 2015 - V 0.3.24.1
  VIX-53    - Error in saving profile information.
  VIX-54    - Stack when adding or deleting channeles.

22 JAN 2015 - V 0.3.22.1
   VIX-52   - Broke the save as... for Vixen 2.x - this is now fixed.  We also try to make going back and forth painless.
   VIX-40   - International dates cause a crash, thought this was fixed, but it cam back, hopefully squished once and for good.
   NO JIRA  - Fixed a channel numbering bug, did not seem to impact any users - whew!
   NO JIRA  - Major architectural changes to support other file types. 
   NO JIRA  - Added support for up to 100 frames per second, 10ms, timing.
   NO JIRA  - Keyboard shortcut cleanup and some more consistency changes.
   NO JIRA  - Lots of internal clean up.

3 JNE 2014 - V 0.2.154.1
   NO JIRA - Removed some duplicate code.
   NO JIRA - Nutcracker rendering info was not displaying properly
   NO JIRA - Version would try to update even though the user had a later version
   VIX-38  - At the end of a sequence, if user had channel highlight on, a crash would occur.

30 MAY 2014 - V 0.2.150.2
   VIX-1   - Fixed Resolution Error (DPI 125% tested and all is well, not tested with > 125%)
   NO JIRA - Fixed a couple of edge case index errors.
   NO JIRA - Added Tool Tips to paste preview (since I forgot the hotkey, others might have too)

30 MAY 2014 - V 0.2.150.1
   NO JIRA - Turned auto-update back on.
   VIX-34  - All file handling in Roadie now handles exceptions gracefully.
   NO JIRA - Fixed spelling errors in this file.
   VIX-22  - Trapped error when closing where Vixen+ throws an ObjectDisposedException.  Now logging it to crash.log
   VIX-16  - Added Channel Highlight on Playback, default to off in preferences.
   VIX-35  - Hide speed controls if there is not any audio attached to a sequence.

28 MAY 2014 - V 0.2.148.1
   VIX-33 - Fixed crash on add multiple in Roadie.
   VIX-30 - Launch crash fixed. Was trying to use an object that had not been initialized.
   VIX-29 - Build error caused a couple of 3rd party libraries not to be included and would cause an Engine8 crash.

26 MAY 2014 - V 0.2.146.1
   VIX-5 - New profile editor, plug in editor, sort editor, group editor and nutcracker model editor.
   NO JIRA - Consolidated Nutcracker into one DLL instead of many to keep the version and such in sync.
   NO JIRA - Removed the diagnostics and timer routines since they were not necessary and were a hold over from version 2.x
   NO JIRA - Fixed some pesky design time errors that have been plaguing me for a year!
   NO JIRA - Lots and lots of internal clean up
   VIX-19  - Removed 10 & 15% from zoom levels, default to 20% if those values are in Preferences or Group Zoom Levels.
   NO JIRA - Removed the evil that was Sort Orders and converted them to groups.  Added a value in the profile that indicates they are sort orders so that when Save As... it will work.

10 FEB 2014 - V 0.2.41.1
   VIX-14 - Fixed - Creating a profile from a sequence cause a hard crash.

07 FEB 2014 - V 0.2.38.1
   VIX-13 - Fixed - Sequence settings, event period length not working correctly.
   VIX-14 - Fixed - Can not create new sequence from Wizard, crash log.
   VIX-4  - Fixed - Group issues resolved.  When you create a sequence you no longer need to close and reopen.  Also, when you edit group information, other sequences are notified of that change as well.
   VIX-2  - Fixed - Profile rename does not rename it copies. Also, now we don't "touch" each profile every time, only when a change is made. Group info should be copied now as well.

05 FEB 2014 - V 0.2.36.1
   NO JIRA - Added better logging to help diagnose update issues.  Created an Update.log file for these logs.

03 FEB 2014 - V 0.2.34.1
   NO JIRA - Batch file was not working on Windows XP, root cause, find returns error level 1 on success and fail.
   Added some logging on failure in the update dialog to ensure I could troubleshoot issues better.

02 FEB 2014 - V 0.2.33.4
   NO JIRA - Found that ElfPreview was not loading since it was looking for a specific type interface instead of a generic one. Replaced the specific type and made to do item to replace once Rob and I can collaborate.

02 FEB 2014 - V 0.2.33.3
   A New Record for Fixes in one day.
   VIX-12 - Fixed a preference bug, was trying to set a value for a timer I had removed from preferences, but didn't remove from program.

02 FEB 2014 - V 0.2.33.2
   Fixed auto update bug when you were up to date, it didn't close.

02 FEB 2014 - V 0.2.33.1
   Implemented VIX-8 & VIX-11 - Added auto update, the ability to set the update check frequency or disable in preferences and the ability to read release notes before downloading.

01 FEB 2014 - V 0.2.32.1
   Bug #133 - FIXED - Insert paste is not working correctly and undo doesn't undo every change, you lose events at the end of the line.
   Bug #134 - FIXED - Color's don't update in profile editing screen when you exit from color dialog.
   Added more detail to channel XML checking if a Null Reference Exception is thrown.
   Added the ability to select all events for a channel in the channel context menu. (Right click on a channel)
   Added the ability to select all events for a period in the event context menu. (Right click in the waveform)
   Updated FMOD to version 4.44.30
   Bug #135 - FIXED - The title tag from an MP3 file was not being read by FMOD properly, implemented custom solution bypassing flawed FMOD implementation.

09 JAN 2014 - V 0.2.9.1
   Bug #132 - Fixed - Pressing shift for paste preview could cause data to be undone.  Now using F3 key to do paste preview.

08 JAN 2014 - V 0.2.8.1
   Bug #131 - Fixed - Crash when changing sort order on toolbar and then changing again in profile manager.
   Added two new preference items under the general tab
      1) Auto save tool bars (A 2014 Feature Request!)
      2) Number of recent files under the File menu (5 to 20)
   Save cross hair state (A 2014 Feature Request!)
   Save waveform state (A 2014 Feature Request!)
   Paste Preview - Hold down the  (use F3 as of 0.2.9.1) key when in the event grid to see how pasting will look before pasting! (A 2014 Feature Request!)
   Event bookmarks. Hold down shift-ctrl-1 through shift-ctrl-9 to set/reset a event bookmark, and press ctrl-1 through ctrl-9 to move there.
   Auto range play select.  If Event bookmark 1 and 9 are defined, that is what will play if you click Play Range (Alt-F6) (A 2014 Feature Request!)
   Minor internal refactoring.

01 JAN 2014 - V 0.2.1.1
    Bug #123 - FIXED - J1Sys plug in crashes on context menu click (right-click)
    Bug #124 - FIXED - Text in channel mapper pop-up for saving prompt has \n\n
    Bug #125 - FIXED - Profile editing, some controls are not anchored properly.
    Bug #126 - FIXED - Channel Mapper not removing channels that were placed by mistake and then deleted.
    Bug #127 - FIXED - Paste full channel events doesn't work right if a group is selected.
    Bug #128 - FIXED - Selecting a large area and then moving the selection box might cause an exception.
    Bug #129 - FIXED - Sparkle not rendering correctly when you have percentage selected instead of value.
    Bug #130 - FIXED - Open .vix files with Vixen+ causes data directory to be "reset"
    Drag and Drop now supported for .VIX files
    Enhanced how changing the event period re-renders (e.g. go from 10ms to 50ms timing) so that if the original didn't have overlap, the new doesn't either OR if the original did, the new one attempts too as well.
    Hopefully fixed a memory leak when copy and pasting repeated times in various sequences.  Was not releasing redo/undo information when a sequence closed.
    Fixed more grammar errors in this file.

22 SEP 2013 - V 0.1.265.1  {BETA}
    Fixed grammar errors in release notes.  I'm a programmer, not a speller :D
    Fixed a channel count weirdness where the wrong count was shown when a group is selected.
    Added an extension method so that logging to crash.log can be called from any class.
    Bug #119 - FIXED - Channel events not working properly with groups, will put the marks on wrong channel.
    Bug #120 - FIXED - Ctrl-s (Save) is opening the sparkle function if the sequence is already in a saved state.
    Integrated the channel mapper into Vixen+
    Bug #121 - KNOWN ISSUE - If you select a light waveform background color, the tick marks are hard to see.
    Bug #122 - KNOWN ISSUE - If you use a profile with groups and use the wizard to create a new sequence, the groups do not show when the sequence is open.  Close the sequence and reopen it before doing anything with groups.  If you don't you will lose your existing group data.

02 SEP 2013 - V 0.1.245.1  {BETA}
    Bug #111 - FIXED - Red X of death.  When managing profiles, exiting can cause the Red X of death. 
    Bug #112 - ISSUE IN ELF - Elf does not work when a group is selected.
    Bug #113 - FIXED - Sort Order will move up by one when edit/manage a profile, eventually crashing the system.
    Bug #114 - MITIGATED - Looping will cause a crash if let running for a long period. "Fix" writes to crash.log if the values are out of range to help with root cause diagnostics.
    Bug #115 - FIXED - Drawing intensity in percentage mode sets intensity to the incorrect level.
    Bug #116 - FIXED - Selecting sequence length on toolbar and pressing enter says it reset the length even though nothing changed.
    Bug #117 - CAN NOT REPRODUCE - Channel Order does not show correctly on toolbar when a sequence is opened. Tested with both profile and non-profile sequences.
    Bug #118 - FIXED - Test channels and test console open multiple instances.

31 AUG 2013 - V 0.1.243.1  {BETA}
    Bug #104 - FIXED - Beat track tapping in audio dialog not working.
    Bug #105 - FIXED - Channel count on toolbar not updated correctly when creating new sequence.
    Bug #106 - NOT FIXED - Profile rename actually copies profile and doesn't rename.
    Bug #107 - FIXED - Profile rename can overwrite an existing profile if the same name is used.
    Bug #108 - FIXED - Remove a channel crashes when trying to rename channels after removing a channel.
    Bug #109 - FIXED - Routine dialog crashes when there are not any routines to select.
    Bug #110 - CAN NOT REPRODUCE - Sort order UI has some weird behavior when moving channels around.
    Grammar errors fixed.
    Buttons fixed on profile dialog screen. No text was appearing.

26 JLY 2013 - V 0.1.207.1  {BETA}
    Bug #100 - NOT FIXED - Certain DPI do not render well in Vixen+. See forum for work around.
    Bug #101 - FIXED - Crash when small grid window and a cell get clicked.
    Bug #102 - FIXED - SaveAs...crashes when there is nothing to save.
    Bug #103 - FIXED - Channel context menu doesn't operate with mapped channels correctly.
    Enhancement - Context copy channel now use the clicked channel as the default source.
    Enhancement - (partial fix for errors from bug #100) - Can select, in preferences, if you want to use the check mark for highlighting selections or just use the regular windows methodology.
    Enhancement - Buggos.

20 JLY 2013 - V 0.1.201.1  {BETA}
    Bug #11 - Under specific circumstances, fire effects (and possibly others) will not render properly.  Found that the effect was not being initialized properly in all cases.
    Bug #12 - Updating sequence length on the tool bar did not change sequence.  (Need to press Enter) There were various presumptions that I made about this tool and that impacted the implementation, mimic what KC did in 2.5.
    Bug #13 - Updating channel count on the tool bar did not change channel count.  (Need to press Enter) There were various presumptions that I made about this tool and that impacted the implementation, mimic what KC did in 2.5.
    Bug #14 - Deleting a channel from a group deletes all channels with the same name.  Now check that name and underlying channel number match.
    Bug #15 - Some combination of changes to a group and sequence will cause the group to be out of sync with the sequence.  Now save the group only when the sequence is saved.
    Bug #16 - Zoom levels are not saving with groups.  Saving now when sequence is saved.
    Bug #17 - Add and remove channels from the main screen works properly now on groups as well.
    Disabled Nutcracker (Not done)
    Disabled UI indicator for bookmarks (Is crashing UI at times)
    Disabled Automatic update checking (Is crashing on server timeout at times)
    Code cleanup, changed static class to extension methods where it made sense.  Code reads cleaner.
    Killed off 9 different TODO items.
    

06 JLY 2013 - V 0.0.186.1 (Private BETA)
    Bug #9 Fixed, Improper setup of preview was not handled gracefully.  Now we just state in setup that it is not setup properly and don't crash.
    Bug #10 Fixed, Channel mapping was not working for everything.  Rewrite of the mapping portions and how the effects that use them.
    Added more robust, hopefully, logging of errors.
    Added Routine color preference
    Code clean up and did some old to do tasks.

04 JLY 2013 - V 0.0.184.1 (Private BETA)
    Bug #5 Fixed, Undo/Redo not working right on non 1 to 1 channel mapping.  Ripped out the old way of doing undo/redo of passing channel numbers around and just pass a reference to the channel object itself.
    Bug #6 Fixed, Random took too long to generate on large selections.  I was iterating over the entire collection on each generation to ensure the saturation was correct, implemented that algorithm to be more efficient.
    Bug #7 Fixed, Random would not generate proper levels if Vary Intensity was selected and was using percentages. I was calculating the value from % twice, causing an incorrect value.
    Bug #8 Fixed, Can't double click on the last row. The label that follows the selection was getting in the way and receiving the click.  I made a new label control that windows sees as transparent and will not capture the click allowing it to pass through to the underlying control.
    Removed some dead code.
    Nutcracker will now render (well somewhat) it will post all effects starting in the first row and column.
    Polished up the initial directory selection and added a link to that dialog in preferences.
    Proper grammar in credits.
    Final step of sequence creation wizard will now change next button to create it.

02 JLY 2013 - V 0.0.182.2 (Private BETA)
    Bug #4 Fix: If you select more than one row and then paste that selection on the last row, system crashes. Was not checking if the paste went beyond the last row when storing undo/redo data.

02 JLY 2013 - V 0.0.182.1 (Private BETA)
    Bug #3 Fix: If nutcracker default files were missing or not found, would crash.  Removed the need for default files by just adding them programmatically if needed.
    Added this ReleaseNotes.txt file
    Added License files to the releases
    Fixed Names in Credits
    Removed use of redirect.data and added data.dir.  Now will ask user upon first run for data directory
    Added Version # to crash.log
    Took all of the libraries out of the project root

01 JLY 2013 - V 0.0.181.1 (Private BETA)
    Released J1Sys Output plug in
    Renamed the redirect.data file to redirect.data.no so that the default behavior will occur.
    Bug #2 Fix: If channel output orders do not match channel number, groups do not work properly. Was only capturing the channel output number, not the channel number.

30 JNE 2013 - V 0.0.180.2 (Private BETA)
    Change Build Number Layout (Major.Minor.BuildDay.BuildNum)
    Bug #1 Fix: Will not persist any changes to channel properties when using a profile. Was not persisting the profile on a change to these properties.
    Released the Open DMX and DMX Pro Output Plugins

30 JNE 2013 - V 0.0.1.180 (Private BETA)
    Initial Private Beta Release
