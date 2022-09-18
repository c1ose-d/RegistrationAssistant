using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationAssistant
{
    internal class PasswordGenerator
    {
        Random random = new Random();

        int[,] lines =
        {
            { 48, 58 },
            { 65, 91 },
            { 97, 123 }
        };

        public string Execute()
        {
            if (TryGenerate(out string password)) return password;
            else return Execute();
        }

        bool TryGenerate(out string password)
        {
            password = "";
            int[] passwordLines = new int[8];
            for (int i = 0; i < 8; i++)
            {
                passwordLines[i] = random.Next(0, 3);
                password += Convert.ToChar(random.Next(lines[passwordLines[i], 0], lines[passwordLines[i], 1])).ToString();
            }
            if (passwordLines.Contains(0) && passwordLines.Contains(1) && passwordLines.Contains(2)) return true;
            else return false;
        }
    }
}
