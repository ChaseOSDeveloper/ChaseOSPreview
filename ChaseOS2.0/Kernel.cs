﻿using ChaseOS2._0.ChaseGraphicsAPI;
using Cosmos.Core;
using Cosmos.HAL;
using Cosmos.System.FileSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Sys = Cosmos.System;
namespace ChaseOS2._0
{
    public class Kernel : Sys.Kernel
    {
        private const string V = "DHSHGKJDHHDKJBKHBHSBVHDH";
        private static Graphics gui;
        public string cddefault;
        public bool login;
        public bool driveCon;
        CosmosVFS FileManager = new Sys.FileSystem.CosmosVFS();
        CosmosVFS Backup = new Sys.FileSystem.CosmosVFS();

        protected override void BeforeRun()
        {
            try
            {
                Console.WriteLine("Welcome to ChaseOS, the calculator that can store files!");
                Console.WriteLine("preparing file system");
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(FileManager);

                Console.WriteLine("filesystem ready");

                Console.WriteLine("loading login");
            }
            catch
            {

            }

            cddefault = @"0:\";

            try
            {
                int shutdown = 0;
                if (FileManager.GetFile(@"0:\login.txt") != null && FileManager.GetFile(@"0:\loginData.txt") != null)
                {
                    var thing = FileManager.GetFile(@"0:\login.txt");
                    var thingr = FileManager.GetFile(@"0:\loginData.txt");
                    var check = thing.GetFileStream();

                    byte[] dataread1 = new byte[1];
                    byte[] dataread2 = new byte[1];
                    var datastream1 = thingr.GetFileStream();
                    datastream1.Read(dataread1, 0, 1);
                    datastream1.Read(dataread2, 0, 1);
                    int data1 = Convert.ToInt32(Encoding.Default.GetString(dataread1));
                    int data2 = Convert.ToInt32(Encoding.Default.GetString(dataread2));
                    byte[] buffer = new byte[data1];
                    string UsernameReal = "";





                    check.Read(buffer, 0, (data1));
                    UsernameReal = Encoding.Default.GetString(buffer);

                    string pass;
                    byte[] passWordReal = new byte[data2];
                    check.Read(passWordReal, 0, (data2));
                    pass = Encoding.Default.GetString(passWordReal);
                    check.Close();

                    while (login == false)
                    {
                        Console.WriteLine("Username?");
                        string user = Console.ReadLine();
                        Console.WriteLine("Password:");
                        string password = Console.ReadLine();
                        if (user == UsernameReal && password == pass)
                        {
                            login = true;
                            Console.WriteLine("Welcome " + user);
                        }
                        else
                        {
                            Console.WriteLine("The username or password you entered is incorrect, try again");
                            shutdown += 1;
                            if (shutdown == 6)
                            {
                                Console.WriteLine("Failed to login more than 6 times...");
                                Console.WriteLine("Press enter to shutdown.");
                                Console.ReadLine();
                                Sys.Power.Shutdown();
                            }
                        }

                    }

                }
                else
                {
                    Console.WriteLine("Try it or install it?");
                    string a = Console.ReadLine();
                    if (a == "install")
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateFile(@"0:\login.txt");
                        Sys.FileSystem.VFS.VFSManager.CreateFile(@"0:\loginData.txt");
                        Console.WriteLine("Welcome to Chase OS! Lets get some things started.");
                        Console.WriteLine("Setup your username:");

                        string user = Console.ReadLine();
                        Console.WriteLine("Setup password for login:");
                        string password = Console.ReadLine();
                        Console.WriteLine("Preparing...");
                        var file = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\login.txt");
                        var filestream = file.GetFileStream();
                        string contents = @"" + user + "" + password;
                        byte[] data = Encoding.ASCII.GetBytes(contents);
                        filestream.Write(data, 0, (int)contents.Length);
                        var file2 = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\loginData.txt");
                        var filestream2 = file2.GetFileStream();
                        string contents2 = @"" + user.Length + "" + password.Length;
                        byte[] data2 = Encoding.ASCII.GetBytes(contents2);
                        filestream2.Write(data2, 0, (int)contents2.Length);

                    }
                    else
                    {
                        while (true)
                        {
                        A:
                            try
                            {
                                Console.Write("ChaseOS>");
                                string cmd = Console.ReadLine();


                                if (cmd == "graphics")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "reese")
                                {
                                    goto A;
                                }
                                if (cmd == "checkram")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "checkcycles")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }

                                if (cmd == "checkuptime")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "checkvendorname")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "clear")
                                {
                                    Console.Clear();
                                    goto A;
                                }
                                if (cmd == "shutdown")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "quickformat")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "format")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "restart")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "help")
                                {
                                    Console.WriteLine("cmds: version, calc, readfile, ls, createfile, editfile, deletefile, help, createdirectory, removedirectory, cd, cdfullpath, time, settings, pwd, graphics, clear, setdrive, quickformat, format");
                                    goto A;
                                }
                                if (cmd == "pwd")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "version")
                                {
                                    Console.WriteLine("Version: 21.0, ChaseOS is an Operating system which is a small project, there is no gui design.");
                                    Console.WriteLine("Credits to Reese or chickendad#3076 for being a developer. Owner: Chase or dff#1307");
                                    goto A;
                                }
                                if (cmd == "createdirectory")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "cd")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "cdfullpath")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "time")
                                {
                                    Console.WriteLine(DateTime.Now.ToString());
                                    goto A;
                                }
                                if (cmd == "echo")
                                {
                                    Console.WriteLine("Text?");
                                    string text = Console.ReadLine();
                                    Console.WriteLine(text);
                                    goto A;
                                }
                                if (cmd == "settings")
                                {
                                    Console.WriteLine("What color for text color?");
                                    string color = Console.ReadLine();
                                    if (color.ToLower() == "blue")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                    }
                                    if (color.ToLower() == "red")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                    }
                                    if (color.ToLower() == "yellow")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                    }
                                    if (color.ToLower() == "green")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                    }
                                    if (color.ToLower() == "black")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Black;
                                    }
                                    if (color.ToLower() == "blue")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                    }
                                    if (color.ToLower() == "cyan")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                    }
                                    if (color.ToLower() == "darkblue")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    }
                                    if (color.ToLower() == "darkred")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                    }
                                    if (color.ToLower() == "darkyellow")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    }
                                    if (color.ToLower() == "gray")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                    }
                                    if (color.ToLower() == "magenta")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                    }
                                    if (color.ToLower() == "white")
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    goto A;
                                }
                                if (cmd == "calc")
                                {
                                    // Declare variables and then initialize to zero.
                                    int num1 = 0; int num2 = 0;

                                    // Display title as the C# console calculator app.
                                    Console.WriteLine("Welcome to the ChaseOS calculator\r");
                                    Console.WriteLine("------------------------\n");

                                    // Ask the user to type the first number.
                                    Console.WriteLine("Type a number, and then press Enter");


                                    // Ask the user to choose an option.
                                    Console.WriteLine("Choose an option from the following list:");
                                    Console.WriteLine("\ta - Add");
                                    Console.WriteLine("\ts - Subtract");
                                    Console.WriteLine("\tm - Multiply");
                                    Console.WriteLine("\td - Divide");
                                    Console.WriteLine("\tsq - Square");
                                    Console.WriteLine("\tsqr - Square root");
                                    Console.Write("Which option do you want to do? ");

                                    // Use a switch statement to do the math.
                                    switch (Console.ReadLine())
                                    {
                                        case "a":
                                            Console.WriteLine("Enter a number");
                                            num1 = Convert.ToInt32(Console.ReadLine());
                                            // Ask the user to type the second number.
                                            Console.WriteLine("Type another number, and then press Enter");
                                            num2 = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
                                            break;
                                        case "s":
                                            Console.WriteLine("Enter a number");
                                            num1 = Convert.ToInt32(Console.ReadLine());

                                            // Ask the user to type the second number.
                                            Console.WriteLine("Type another number, and then press Enter");
                                            num2 = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
                                            break;
                                        case "m":
                                            Console.WriteLine("Enter a number");
                                            num1 = Convert.ToInt32(Console.ReadLine());

                                            // Ask the user to type the second number.
                                            Console.WriteLine("Type another number, and then press Enter");
                                            num2 = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
                                            break;
                                        case "d":
                                            Console.WriteLine("Enter a number");
                                            num1 = Convert.ToInt32(Console.ReadLine());

                                            // Ask the user to type the second number.
                                            Console.WriteLine("Type another number, and then press Enter");
                                            num2 = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
                                            break;
                                        case "sq":
                                            Console.WriteLine("What number to square?");
                                            num1 = Convert.ToInt32(Console.ReadLine());
                                            // Ask the user to type the second number.
                                            Console.WriteLine($"Your result: " + num1 + " * " + num1 + " = " + (num1 * num1));
                                            break;
                                        case "sqr":
                                            Console.WriteLine("What number to find the square root of?");
                                            double hi = Math.Sqrt(Convert.ToDouble(Console.ReadLine()));
                                            Console.WriteLine($"Your result: " + hi);
                                            break;
                                    }
                                    // Wait for the user to respond before closing.

                                    goto A;
                                    // bruh
                                }
                                if (cmd == "removedirectory")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                }
                                if (cmd == "createfile")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                }
                                if (cmd == "editfile")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "deletefile")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "copy")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "box")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                }
                                if (cmd == "ls")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "readfile")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "setdrive")
                                {
                                    Console.WriteLine("The demo version doesnt support this command! Download the full version for all the commands.");
                                    goto A;
                                }
                                if (cmd == "")
                                {
                                    goto A;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid cmd. Please try again. Type help for a list of commands.");
                                }


                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("An error has occured.");
                                Console.WriteLine(e.ToString());

                            }
                        }
                    }

                }


            }
            catch (Exception e)
            {
                Console.WriteLine("The error '" + e.ToString() + "' occured on startup, attempting to contine with os, some features will be broken due to this.");
                Console.ReadLine();
                // Filemanager might be corrupted, set it to null.
                FileManager = Backup;
                Run();
            }
        }
        protected override void Run()
        {
            try
            {

                if (Kernel.gui != null)
                {
                    Kernel.gui.MouseHandler();
                    return;
                }
                Console.Write("Time: " + DateTime.Now + " Path: " + cddefault + " ChaseOS>");
                string cmd = Console.ReadLine();
                if (cddefault.EndsWith(@"\"))
                {

                }
                else
                {
                    cddefault = cddefault + @"\";
                }
                if (cmd == "graphics")
                {
                    Console.WriteLine("ALERT! Graphics mode is in beta, and may not work. Continue? Y/N");
                    string confirm = Console.ReadLine();
                    if (confirm == "Y")
                    {
                        Kernel.gui = new Graphics();

                    }
                    return;
                }
                if (cmd == "reese")
                {
                    return;
                }
                if (cmd == "checkram")
                {
                    Console.WriteLine(CPU.GetAmountOfRAM() + " MB");
                    return;
                }
                if (cmd == "checkcycles")
                {
                    Console.WriteLine(CPU.GetCPUCycleSpeed() + " GHz");
                    return;
                }

                if (cmd == "checkuptime")
                {
                    Console.WriteLine(CPU.GetCPUUptime());
                    return;
                }
                if (cmd == "checkvendorname")
                {
                    Console.WriteLine(CPU.GetCPUVendorName());
                    return;
                }
                if (cmd == "clear")
                {
                    Console.Clear();
                    return;
                }
                if (cmd == "shutdown")
                {
                    Sys.Power.Shutdown();
                    return;
                }
                if (cmd == "quickformat")
                {
                    Console.WriteLine(@"Drive? Example: 0:\");
                    string driveId = Console.ReadLine();
                    FileManager.Format(driveId, "FAT32", true);
                    return;
                }
                if (cmd == "format")
                {
                    Console.WriteLine(@"Drive? Example: 0:\");
                    string driveId = Console.ReadLine();
                    FileManager.Format(driveId, "FAT32", false);
                    return;
                }
                if (cmd == "restart")
                {
                    Sys.Power.Reboot();
                    return;
                }
                if (cmd == "help")
                {
                    Console.WriteLine("cmds: version, calc, readfile, ls, createfile, editfile, deletefile, help, createdirectory, removedirectory, cd, cdfullpath, time, settings, pwd, graphics, clear, setdrive, quickformat, format");
                    return;
                }
                if (cmd == "pwd")
                {
                    Console.WriteLine(cddefault);
                    return;
                }
                if (cmd == "version")
                {
                    Console.WriteLine("Version: 21.0, ChaseOS is an Operating system which is a small project, there is no gui design.");
                    Console.WriteLine("Credits to Reese or chickendad#3076 for being a developer. Owner: Chase or dff#1307");
                    return;
                }
                if (cmd == "createdirectory")
                {
                    Console.WriteLine("directory name?");
                    string prefolder = Console.ReadLine();
                    FileManager.CreateDirectory(@cddefault + prefolder);
                    Console.WriteLine("Directory created.");
                    return;
                }
                if (cmd == "cd")
                {
                    Console.WriteLine("Path to get to?");
                    string precd = Console.ReadLine();
                    cddefault = @cddefault + precd;
                    Console.WriteLine("Now in path directory");
                    return;
                }
                if (cmd == "cdfullpath")
                {
                    Console.WriteLine("full path?");
                    string predest = Console.ReadLine();
                    cddefault = @predest;
                    return;
                }
                if (cmd == "time")
                {
                    Console.WriteLine(DateTime.Now.ToString());
                    return;
                }
                if (cmd == "echo")
                {
                    Console.WriteLine("Text?");
                    string text = Console.ReadLine();
                    Console.WriteLine(text);
                    return;
                }
                if (cmd == "settings")
                {
                    Console.WriteLine("What color for text color?");
                    string color = Console.ReadLine();
                    if (color.ToLower() == "blue")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (color.ToLower() == "red")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (color.ToLower() == "yellow")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (color.ToLower() == "green")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (color.ToLower() == "black")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (color.ToLower() == "blue")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (color.ToLower() == "cyan")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    if (color.ToLower() == "darkblue")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    if (color.ToLower() == "darkred")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    if (color.ToLower() == "darkyellow")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    if (color.ToLower() == "gray")
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    if (color.ToLower() == "magenta")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    if (color.ToLower() == "white")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    return;
                }
                if (cmd == "calc")
                {
                    // Declare variables and then initialize to zero.
                    int num1 = 0; int num2 = 0;

                    // Display title as the C# console calculator app.
                    Console.WriteLine("Welcome to the ChaseOS calculator\r");
                    Console.WriteLine("------------------------\n");

                    // Ask the user to type the first number.
                    Console.WriteLine("Type a number, and then press Enter");


                    // Ask the user to choose an option.
                    Console.WriteLine("Choose an option from the following list:");
                    Console.WriteLine("\ta - Add");
                    Console.WriteLine("\ts - Subtract");
                    Console.WriteLine("\tm - Multiply");
                    Console.WriteLine("\td - Divide");
                    Console.WriteLine("\tsq - Square");
                    Console.WriteLine("\tsqr - Square root");
                    Console.Write("Which option do you want to do? ");

                    // Use a switch statement to do the math.
                    switch (Console.ReadLine())
                    {
                        case "a":
                            Console.WriteLine("Enter a number");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            // Ask the user to type the second number.
                            Console.WriteLine("Type another number, and then press Enter");
                            num2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
                            break;
                        case "s":
                            Console.WriteLine("Enter a number");
                            num1 = Convert.ToInt32(Console.ReadLine());

                            // Ask the user to type the second number.
                            Console.WriteLine("Type another number, and then press Enter");
                            num2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
                            break;
                        case "m":
                            Console.WriteLine("Enter a number");
                            num1 = Convert.ToInt32(Console.ReadLine());

                            // Ask the user to type the second number.
                            Console.WriteLine("Type another number, and then press Enter");
                            num2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
                            break;
                        case "d":
                            Console.WriteLine("Enter a number");
                            num1 = Convert.ToInt32(Console.ReadLine());

                            // Ask the user to type the second number.
                            Console.WriteLine("Type another number, and then press Enter");
                            num2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
                            break;
                        case "sq":
                            Console.WriteLine("What number to square?");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            // Ask the user to type the second number.
                            Console.WriteLine($"Your result: " + num1 + " * " + num1 + " = " + (num1 * num1));
                            break;
                        case "sqr":
                            Console.WriteLine("What number to find the square root of?");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            double hi = Math.Sqrt(num1);
                            Console.WriteLine($"Your result: " + hi);
                            break;
                    }
                    // Wait for the user to respond before closing.

                    return;
                }
                if (cmd == "removedirectory")
                {
                    Console.WriteLine("Directory?");
                    string predir = Console.ReadLine();
                    FileManager.DeleteDirectory(FileManager.GetDirectory(@cddefault + predir));
                    Console.WriteLine("The directory " + predir + " was removed succesfully");
                    return;
                }
                if (cmd == "createfile")
                {
                    Console.WriteLine("filename?");
                    string filename = Console.ReadLine();
                    Sys.FileSystem.VFS.VFSManager.CreateFile(@cddefault + filename);
                    Console.WriteLine("File created succesfully");
                    return;
                }
                if (cmd == "editfile")
                {
                    Console.WriteLine("filename?");
                    string filename1 = Console.ReadLine();
                    var file = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + filename1);
                    var filestream = file.GetFileStream();
                    Console.WriteLine("contents");
                    string contents = Console.ReadLine();
                    byte[] data = Encoding.ASCII.GetBytes(contents);
                    filestream.Write(data, 0, (int)contents.Length);
                    Console.WriteLine("file edited sucessfully");
                    return;
                }
                if (cmd == "deletefile")
                {
                    Console.WriteLine("Enter the name of the file");
                    string prefilename2 = Console.ReadLine();
                    var preprefilename2 = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + prefilename2);

                    FileManager.DeleteFile(preprefilename2);
                    Console.WriteLine("The file " + prefilename2 + " has been deleted");
                    return;
                }
                if (cmd == "copy")
                {
                    Console.WriteLine("filename of file to copy");
                    var prefile = Console.ReadLine();
                    var file = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + prefile).GetFileStream();
                    byte[] data = new byte[file.Length];
                    file.Read(data, 0, (int)file.Length);
                    string content = Encoding.Default.GetString(data);



                    Console.WriteLine("filename of the new file");
                    string filename = Console.ReadLine();
                    Sys.FileSystem.VFS.VFSManager.CreateFile(@cddefault + filename);
                    var filenew = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + filename);
                    var filestream = filenew.GetFileStream();
                    byte[] data1 = Encoding.ASCII.GetBytes(content);
                    filestream.Write(data, 0, (int)content.Length);

                    Console.WriteLine("file copied succesfully");
                    return;
                }
                if (cmd == "box")
                {
                    ChaseOS2._0.ChaseGraphicsAPI.Graphics.THE = true;
                    return;
                }
                if (cmd == "ls")
                {
                    var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(@cddefault);
                    foreach (var directoryEntry in directory_list)
                    {
                        Console.WriteLine(directoryEntry.mName);
                    }
                    return;
                }
                if (cmd == "readfile")
                {
                    Console.WriteLine("filename?");
                    var prefile = Console.ReadLine();
                    var file = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + prefile).GetFileStream();
                    byte[] data = new byte[file.Length];
                    file.Read(data, 0, (int)file.Length);
                    Console.WriteLine(Encoding.Default.GetString(data));
                    return;
                }
                if (cmd == "setdrive")
                {
                    Console.WriteLine(@"Drive? Example: 0:\");
                    string driveid = Console.ReadLine();
                    bool validDrive = FileManager.IsValidDriveId(driveid);
                    if (validDrive)
                    {
                        Console.WriteLine("Warning: Drive can be corrupted when changes are made to the drive. Continue? Y/N");
                        string confirm = Console.ReadLine();
                        if (confirm == "Y")
                        {
                            cddefault = driveid;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The drive name you entered is invalid.");
                    }
                    return;
                }
                if (cmd == "")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid cmd. Please try again. Type help for a list of commands.");
                }


            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Your computer ran into a problem, and the errorcode is");
                Console.WriteLine(e.ToString());
                Console.WriteLine("Restarting in 5 seconds...");
                WaitSeconds(5);
                Sys.Power.Reboot();
            }
        }
        public static void WaitSeconds(int secNum)
        {
            int StartSec = RTC.Second;
            int EndSec;
            if (StartSec + secNum > 59)
            {
                EndSec = 0;
            }
            else
            {
                EndSec = StartSec + secNum;
            }
            while (RTC.Second != EndSec)
            {
                // Loop round
            }
        }
    }
}