using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Interpreter.message;

namespace Interpreter.frontend
{
    public class Source : MessageProducer
    {
        public const char EOL = '\n'; // end-of-line character
        public const char EOF = (char)0; // end-of-file-character

        private StreamReader reader; // reader for the source program
        private string line; // source line
        public int lineNum { get; private set; } // current source line number
        public int currentPos { get; private set; } // current source line position

        private MessageHandler messageHandler; // delegate to handle messages

        public Source(StreamReader reader)
        {
            this.lineNum = 0;
            this.currentPos = -2; //set to -2 to read the first source line
            this.reader = reader;
            this.messageHandler = new MessageHandler();
        }

        public char currentChar()
        {
            // first time?
            if (currentPos == -2)
            {
                readLine();
                return nextChar();
            }

            // end of file?
            else if (line == null)
                return EOF;

            // end of line?
            else if ((currentPos == -1) || (currentPos == line.Length))
                return EOL;

            // need to read next line?
            else if (currentPos > line.Length)
            {
                readLine();
                return nextChar();
            }

            // return the character at the current position
            else
                return line[currentPos];
        }

        // consume current source character and return next character
        public char nextChar()
        {
            ++currentPos;
            return currentChar();
        }

        // return the source character following the current character without consuming the current character
        public char peekChar()
        {
            currentChar();
            if (line == null)
                return EOF;

            int nextPos = currentPos + 1;
            return nextPos < line.Length ? line[nextPos] : EOL;
        }

        // read the next source line
        private void readLine()
        {
            line = reader.ReadLine(); // null when at the end of the source
            currentPos = -1;

            if (line != null)
            {
                ++lineNum;
                // Send a source line message containing the line number
                // and the line text to all the listeners.
                sendMessage(new Message(MessageType.SOURCE_LINE, new Object[] { lineNum, line }));
            }
        }

        // close the source
        public void close()
        {
            if (reader != null)
            {
                try
                {
                    reader.Close();
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.ToString());
                    throw e;
                }
            }
        }

        // Add a parser message listener
        public void addMessageListener(MessageListener listener)
        {
            messageHandler.addListener(listener);
        }

        // Remove a parser message listener
        public void removeMessageListener(MessageListener listener)
        {
            messageHandler.addListener(listener);
        }

        // Notify listeners after setting the message
        public void sendMessage(Message message)
        {
            messageHandler.sendMessage(message);
        }
    }
}
