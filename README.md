# Cybersecurity Awareness Chatbot

## Overview
This is a simple console-based chatbot designed to help users learn about cybersecurity awareness. The chatbot provides information on various cybersecurity topics, such as phishing, strong passwords, VPNs, malware, and safe browsing.

## Features
- Plays a voice greeting when the program starts.
- Displays an ASCII art logo from an image.
- Greets the user and starts a conversation.
- Provides predefined responses to cybersecurity-related questions.
- Simulates a typing effect for a more interactive experience.
- Allows users to exit the chat by typing "exit".

## Technologies Used
- C# (.NET)
- System.Drawing for image processing (ASCII art generation)
- System.Media for playing sound files
- System.Threading for simulated typing effect

## Prerequisites
- .NET installed on your system
- A console environment (Windows Command Prompt, PowerShell, or Terminal)
- A `greeting.wav` file in the root directory of the project
- A `logo.png` file in the root directory of the project

## Installation & Setup
1. Clone this repository or download the source code.
2. Ensure that `greeting.wav` and `logo.png` are placed in the project root directory.
3. Open the project in Visual Studio or any C# compatible IDE.
4. Build and run the project.

## How to Use
1. Run the program.
2. Enter your name when prompted.
3. Start asking cybersecurity-related questions.
4. Type "exit" to close the chat.

## Example Questions
- "What is a strong password?"
- "Tell me about phishing."
- "How does a VPN work?"
- "What is malware?"

## Known Issues
- If `greeting.wav` or `logo.png` is missing, the program may display an error.
- ASCII art generation may not look perfect depending on console font settings.

## Future Enhancements
- Add more AI-based response generation.
- Implement a GUI version of the chatbot.
- Improve ASCII image rendering.
- Integrate external APIs for up-to-date cybersecurity news.

---
