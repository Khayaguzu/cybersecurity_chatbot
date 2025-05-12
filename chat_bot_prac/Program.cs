using System;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Collections.Generic;

namespace chat_bot_prac
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Play a voice greeting when the program starts
            PlayVoice();

            // Display logo using ASCII art from an image
            DisplayImage();

            // Get user's name and welcome them
            string userName = GetUserName();
            DisplayWelcomeMessage(userName);

            // Ask the first question and set the color to Cyan
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypeText($"Chatbot-> What can I help with, {userName}?", 30);
            Console.ResetColor();

            // Start chatbot conversation
            StartChat(userName);
        }

        static void PlayVoice()
        {
            // Get the full project directory
            string full_location = AppDomain.CurrentDomain.BaseDirectory;
            string new_path = full_location.Replace("bin\\Debug\\", "");

            try
            {
                // Build the full path to the greeting.wav file
                string full_path = Path.Combine(new_path, "greeting.wav");

                // Play the sound file synchronously
                using (SoundPlayer play = new SoundPlayer(full_path))
                {
                    play.PlaySync();
                }
            }
            catch (Exception error)
            {
                // Handle any errors in loading or playing the sound
                Console.Write(error.Message);
            }
        }

        static void DisplayImage()
        {
            // Get full location of the project and remove "bin\\Debug\\" from path
            string full_location = AppDomain.CurrentDomain.BaseDirectory;
            string new_location = full_location.Replace("bin\\Debug\\", "");

            // Construct the full path to the logo image
            string full_path = Path.Combine(new_location, "logo.png");

            try
            {
                // Load the image and resize it to a smaller size
                Bitmap image = new Bitmap(full_path);
                image = new Bitmap(image, new Size(150, 120));

                // Loop through image pixels and convert to ASCII characters based on grayscale values
                for (int height = 0; height < image.Height; height++)
                {
                    for (int width = 0; width < image.Width; width++)
                    {
                        Color pixelColor = image.GetPixel(width, height);
                        int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                        // Choose ASCII character based on brightness of the pixel
                        char asciiChar = gray > 200 ? '*' : gray > 250 ? 'o' : gray > 200 ? '#' : '@';
                        Console.Write(asciiChar);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception error)
            {
                // Display an error message if the image fails to load
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error loading logo: {error.Message}");
                Console.ResetColor();
            }
        }

        static string GetUserName()
        {
            // Prompt the user to enter their name with yellow text
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your name: ");
            Console.ResetColor();

            string userName = Console.ReadLine();

            // Ensure the user enters a valid name (not empty or whitespace)
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name cannot be empty. Please enter your name:");
                Console.ResetColor();
                userName = Console.ReadLine();
            }
            return userName;
        }

        static void DisplayWelcomeMessage(string userName)
        {
            // Display a welcome message in green with borders for emphasis
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("======================================================================");
            Console.WriteLine($"Hello, {userName}! Welcome to the Cybersecurity Awareness Bot.");
            Console.WriteLine("I'm here to help you stay safe online.");
            Console.WriteLine("======================================================================");
            Console.ResetColor();
        }

        static void TypeText(string text, int delay = 50)
        {
            // Simulate typing effect by outputting one character at a time with a delay
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        static void StartChat(string userName)
        {
            
                List<string> questions = new List<string>();
                List<ArrayList> answers = new List<ArrayList>();

                void Store_Responses()
                {
                    questions.Add("how are you");
                    answers.Add(new ArrayList {
            "I'm just a bot, {userName}, but I'm here to help you stay safe online!",
            "I'm functioning at optimal efficiency! How can I assist you today?"
        });

                    questions.Add("purpose");
                    answers.Add(new ArrayList {
            "My purpose is to educate you about cybersecurity and help you stay safe online.",
            "I'm here to provide tips and answer questions related to online safety and security."
        });

                    questions.Add("password");
                    answers.Add(new ArrayList {
            "A strong password should be at least 12 characters long, with a mix of letters, numbers, and symbols.",
            "Avoid using easily guessable passwords like '123456' or your name.",
            "Use a password manager to generate and store complex passwords securely."
        });

                    questions.Add("phishing");
                    answers.Add(new ArrayList {
            "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.",
            "Check the sender's email address and avoid clicking on suspicious links.",
            "Phishing emails often create a sense of urgency to trick you into revealing personal data."
        });

                    questions.Add("safe browsing");
                    answers.Add(new ArrayList {
            "Always check for 'https://' in the URL and avoid clicking on suspicious links.",
            "Keep your browser updated to protect against known vulnerabilities.",
            "Use trusted antivirus and anti-malware extensions for safer browsing."
        });

                    questions.Add("vpn");
                    answers.Add(new ArrayList {
            "A VPN encrypts your internet traffic, making it safer from hackers.",
            "VPNs help you maintain online privacy, especially on public Wi-Fi.",
            "Choose a reputable VPN service that doesn’t log your data."
        });

                    questions.Add("browsing");
                    answers.Add(new ArrayList {
            "A browser is an application program that provides a way to look at and interact with all the information on the World Wide Web.",
            "Popular browsers include Chrome, Firefox, Safari, and Edge.",
            "Browsers can be enhanced with extensions to improve security and functionality."
        });

                    questions.Add("social engineering");
                    answers.Add(new ArrayList {
            "Social engineering manipulates victims to control systems or steal personal and financial data.",
            "Be cautious of people asking for sensitive info over the phone or via email.",
            "Attackers often impersonate authority figures to trick targets."
        });

                    questions.Add("software attacks");
                    answers.Add(new ArrayList {
            "Software attacks include malware, phishing, and SQL injection, compromising systems and data.",
            "Ensure your software is updated to patch known vulnerabilities.",
            "Firewalls and antivirus programs help detect and block software attacks."
        });

                    questions.Add("computer security");
                    answers.Add(new ArrayList {
            "Computer security is the protection of computer systems and networks from threats that lead to unauthorized access, theft, or damage.",
            "Implementing strong authentication methods is part of good computer security.",
            "Regular system updates and user awareness are key to computer security."
        });

                    questions.Add("malware");
                    answers.Add(new ArrayList {
            "Malware is intrusive software created by cybercriminals to steal data and damage or destroy computer systems. Examples include viruses.",
            "Avoid downloading software from untrusted sources to reduce the risk of malware.",
            "Use antivirus software to detect and remove malware threats."
        });
                }

                Store_Responses();

                // Inform the user on how to exit the chat
                Console.ForegroundColor = ConsoleColor.Magenta;
                TypeText("Chatbot-> Type 'exit' to quit the chat.", 30);
                Console.ResetColor();

                while (true)
                {
                    // Prompt the user for input with yellow text
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{userName}:-> ");
                    Console.ResetColor();

                    // Get user input and normalize it
                    string userInput = Console.ReadLine()?.Trim().ToLower();

                    // Handle empty input
                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        TypeText($"{userName}, I didn’t quite understand that. Could you rephrase?", 30);
                        Console.ResetColor();
                        continue;
                    }

                    // Exit condition for the chat
                    if (userInput == "exit")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        TypeText($"Chatbot-> Goodbye, {userName}! Stay safe online!", 30);
                        Console.ResetColor();
                        break;
                    }

                    bool responseFound = false;

                    // Check if the user's input contains any of the predefined questions
                    for (int i = 0; i < questions.Count; i++)
                    {
                        if (userInput.Contains(questions[i]))
                        {
                            ArrayList possibleAnswers = answers[i];
                            Random rand = new Random();
                            string response = possibleAnswers[rand.Next(possibleAnswers.Count)].ToString();
                            response = response.Replace("{userName}", userName);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            TypeText($"Chatbot-> {response}", 30);
                            Console.ResetColor();
                            responseFound = true;
                            break;
                        }
                    }

                    // If no response matches, ask the user to rephrase their question
                    if (!responseFound)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        TypeText($"Chatbot-> {userName}, I did not quite understand that. Could you please ask questions related to Cybersecurity Awareness?", 30);
                        Console.ResetColor();
                    }
                }
            }
        }
    }

