Different Behaviour on Linux
============================

The original version of Ketarin was written for the .NET environment. This is
not available for Linux, but Mono is a close equivalent. Some behaviours,
however, are different, and can't be fixed easily.

File | Export
------------
When you open the File menu and select one of the Export options, the Windows
version lets you type the beginning of the path to the desired destination and
then tap the Enter key. The program then displays the folders available at that
point in the path. You can type part of a foldername and see options to choose
with the arrow keys.

This works because Windows dialogs won't allow you to save a file named
**".xml"**.  Since Linux systems see that as simply a hidden file, Mono doesn't
have the same restriction, and will save a file named ".xml" in the directory
you entered.  Since this isn't likely to be expected, a prompt will appear,
asking if you want to save the file, giving the full path.  If you answer No,
you'll be able to browse to the desired location, and specify the file name you
want.  If you choose yes, the hidden file will be saved.

In the Linux version it pays to explore to the desired destination with a
command shell or a filesystem explorer, then copy the path to the clipboard.
Then when you File | Export, paste the path into the *File Name* field and add
the desired filename and tap Enter.

File | Import
-------------
There is a similar issue for File | Import, but the reasons behind the Windows
behavior are slightly different.  Again, the best choice is probably to browse
using the mouse, rather than trying to change directories via the keyboard.

PageDown and PageUp
-------------------
In the Linux version, the PdDn key works as expected, but the PgUp key moves
correctly only the first time you tap it. After that it moves up just a line
each time.  This appears to be a bug in Mono.  Once we're able to confirm that,
and submit a bug report, information about the bug report will appear here.

Scrollbars
----------
When you click in the trough area of the scroll bar, the window scrolls, moving
the slider all the way to where you clicked. This is called **_warping_** the
slider. People say that this behaviour can be turned off by putting
```
    [Settings]
    gtk-primary-button-warps-slider = false
```
in ~/.config/gtk-3.0/settings.ini, but this doesn't seem to work.  YMMV, of
course.  Additionally, depending on your desktop environment and configuration,
warping will not be enabled, and you won't notice this behavior.





