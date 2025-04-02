using System;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Media;
using System.Threading;

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
            // Predefined chatbot responses in an array list with keyword-response pairs
            ArrayList responses = new ArrayList
            {
                "how are you|I'm just a bot, {userName}, but I'm here to help you stay safe online!",
                "purpose|My purpose is to educate you about cybersecurity and help you stay safe online.",
                "password|A strong password should be at least 12 characters long, with a mix of letters, numbers, and symbols.",
                "phishing|Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.",
                "safe browsing|Always check for 'https://' in the URL and avoid clicking on suspicious links.",
                "vpn|A VPN encrypts your internet traffic, making it safer from hackers.",
                "browsing|A browser is an application program that provides a way to look at and interact with all the information on the World Wide Web.",
                "social engineering|Social engineering manipulates victims to control systems or steal personal and financial data.",
                "software attacks|Software attacks include malware, phishing, and SQL injection, compromising systems and data.",
                "computer security|Computer security is the protection of computer systems and networks from threats that lead to unauthorized access, theft, or damage.",
                "malware|Malware is intrusive software created by cybercriminals to steal data and damage or destroy computer systems. Examples include viruses."
            };

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
                foreach (string item in responses)
                {
                    // Split each response into keyword and message
                    string[] parts = item.Split('|');
                    if (parts.Length != 2) continue;

                    string keyword = parts[0].Trim().ToLower();
                    string answer = parts[1].Trim();

                    // Check if the user's input contains any keyword from predefined responses
                    if (userInput.Contains(keyword))
                    {
                        // Replace the placeholder {userName} with the actual username
                        answer = answer.Replace("{userName}", userName);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        TypeText($"Chatbot-> {answer}", 30);
                        Console.ResetColor();
                        responseFound = true;
                        break;
                    }
                }

                // If no response matches, ask the user to rephrase their question

                if (!responseFound)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypeText($"Chatbot-> {userName}, I did not quite understand that. Could you please ask questions related to Cybersecurity Awareness", 30);
                    Console.ResetColor();
                }
            }
        }
    }
}
