using System;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        private string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private string Numbers = "0123456789";

        private char EncryptChar(char _char)
        {
            int numero_casas = 3;
            _char = char.ToLower(_char);
            int index = 0;
            if (Alphabet.Contains(_char.ToString()))
            {
                int position = Alphabet.IndexOf(_char) + 1;
                if (position + numero_casas > 26)
                {
                    index = (position + numero_casas) - 26;
                }
                else
                {
                    index = position + numero_casas;
                }

                return Alphabet[index - 1];
            }
            else
            {
                return _char;
            }
        }

        private char DecryptChar(char _char )
        {
            int numero_casas = 3;
            _char = char.ToLower(_char);
            int index = 0;
            if (Alphabet.Contains(_char.ToString()))
            {
                int position = Alphabet.IndexOf(_char) + 1;
                if (position - numero_casas < 1)
                {
                    index = (position - numero_casas) + 26;
                }
                else
                {
                    index = position - numero_casas;
                }

                return Alphabet[index - 1];
            }
            else
            {
                return _char;
            }
        }

        public string Crypt(string message)
        {
            if (message != null)
            {
                string Result = null;
                foreach (char Char in message)
                {
                    char _char = char.ToLower(Char);
                    if (Alphabet.Contains
                        (
                            _char.ToString()) || 
                            _char == ' ' || 
                            Numbers.Contains(_char.ToString())
                        )
                    {

                        Result += EncryptChar(_char);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Caracter inválido");
                    }
                }
                return Result;
            }
            else
            {
                throw new ArgumentNullException("Mensagem nula");
            }
        }

        public string Decrypt(string cryptedMessage)
        {
            if (cryptedMessage != null)
            {

                string Result = null;
                foreach (char Char in cryptedMessage)
                {
                    char _char = char.ToLower(Char);
                    if (Alphabet.Contains
                        (
                            _char.ToString()) || 
                            _char == ' '||
                            Numbers.Contains(_char.ToString())
                        )
                    {
                        Result += DecryptChar(_char);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Caracter inválido");
                    }
                }
                return Result;
            }
            else
            {
                throw new ArgumentNullException("Mensagem nula");
            }
        }
    }
}
