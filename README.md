# Video Shuffler
A solution to trigger videos (or any other file grouping) to launch with a program.

# Why?
Every night I like to fall asleep watching my favorite cartoon. 
But, it has lots of seasons, lots of episodes, and sometimes I watch one season more than another, because I'm too lazy or sleepy to pick episodes I want to rewatch.

So I invented this little tool to help me shuffle everything and play some random videos from my library.

# How does it work?
- It uses Windows registry to record data ~~(pretty overkill, but since it is using local user, there's no need for admin rights)~~.
- You set the files' location (it's just one atm), and it will recursively grab every file path.
- You can filter those files by simply using the same thing you'd use in Windows to look for files.
  - You can use the exclamation mark to invert this. For example, `!*.mp4` would remove every mp4 file from the search.
- Then you update this information, and set the amount of files you want to randomly get.
- Then you execute, and it will:
  - launch the application, 
  - use the files it randomly selected among all files found as command line arguments
  
![image](https://user-images.githubusercontent.com/4689962/153950324-d9064966-26b0-465c-8858-7626299dc7a4.png)

If you launch this application with a command line argument, it will change the execution context. For example:
- Today I want to watch Cartoon A.
  - So I make a shortcut for VideoShuffler with no command line argument
  - It will create a default context in Windows Registry
- Sometimes, I want to watch another show, and none of Cartoon A
  - So I make another shortcut to VideoShuffler with a command line argument: `the other show` - for example
  - It will create another place in registry that will point to this other configuration, so you don't have to change, just use another shortcut.

# Ideas
- Perhaps make room to launch another command (like `shutdown -s -f -t 3600`)
- Make it autonomous (see there is already enough data to load and execute, just do it with a command line arg)
- Watch multiple folders (imagine if I'm in the mood to watch another cartoon?)
  - Today we can have different profiles using a command line argument, which is the context for execution
- Test it more - I made this, because I couldn't believe I was so lazy to do it already 😂
