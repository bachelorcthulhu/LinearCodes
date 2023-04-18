using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCodes
{

    public static class Equations
    {
        /// <summary>
        /// Уравнение вида 2^k - 1 = Q
        /// </summary>
        /// <param name="_messageSize">Q</param>
        /// <param name="_messagePartOfCodeSize">предполагаемое k</param>
        /// <returns>Является ли k решением</returns>
        public static bool MessagePartEquation(int _messageSize, int _messagePartOfCodeSize)
        {
            return Math.Pow(2, _messagePartOfCodeSize) >= _messageSize + 1;
        }

        /// <summary>
        /// Уравнение вида 2^(n-k) - 1 = n
        /// </summary>
        /// <param name="_messagePartOfCodeSize">k</param>
        /// <param name="_codeSize">предполагаемое n</param>
        /// <returns>Является ли n решением</returns>
        public static bool CodeSizeEquation(int _messagePartOfCodeSize, int _codeSize)
        {
            //Console.WriteLine(Math.Pow(2, _codeSize - _messagePartOfCodeSize));
            //Console.WriteLine(_codeSize + 1);
            return Math.Pow(2, _codeSize - _messagePartOfCodeSize) >= _codeSize + 1;
            

        }
        /// <summary>
        /// Вычисляет MessagePartOfCodeSize, то есть k, на основании MessageSize, то есть Q
        /// </summary>
        /// <param name="_messageSize">Q, MessageSize</param>
        /// <returns>MessagePartOfCodeSize, то есть k</returns>
        public static int GetMessagePartOfCodeSize(int _messageSize)
        {
            int MessagePartOfCodeSize = 0;
            while (true)
            {
                if (MessagePartEquation(_messageSize, MessagePartOfCodeSize))
                    return MessagePartOfCodeSize;
                MessagePartOfCodeSize++;
            }
        }
        /// <summary>
        /// Вычисляет CodeSize, то есть n, на основании MessagePartOfCodeSize, то есть k
        /// </summary>
        /// <param name="_messagePartOfCodeSize">K, MessagePartOfCodeSize</param>
        /// <returns>codeSize, то есть n</returns>
        public static int GetCodeSizeEquation(int _messagePartOfCodeSize)
        {
            int codeSize = 0;
            while (true)
            {
                if (CodeSizeEquation(_messagePartOfCodeSize, codeSize))
                    return codeSize;
                codeSize++;
            }
        }
    }

    
    public class Code
    {
        /// <summary>
        /// A.K.A. Q: Сколько нужно закодировать бит информации изначально
        /// </summary>
        public int MessageSize { get; private set; }
        /// <summary>
        /// А.К.А. n: Длина всего закодированного сообщения
        /// </summary>
        public int CodeSize { get; private set; }
        /// <summary>
        /// A.K.A. k: Длина итоговой последовательности битов
        /// </summary>
        public int MessagePartOfCodeSize { get; private set; }
        /// <summary>
        /// A.K.A n - k: Длина избыточной контрольной части 
        /// </summary>
        public int RedundantCheckingPartOfCodeSize { get; private set; }


        public Code(int _messageSize) 
        {
            MessageSize = _messageSize;
            MessagePartOfCodeSize = Equations.GetMessagePartOfCodeSize(MessageSize);
            CodeSize = Equations.GetCodeSizeEquation(MessagePartOfCodeSize);
            RedundantCheckingPartOfCodeSize = CodeSize - MessagePartOfCodeSize;
        }

        public void GetCodeInfo()
        {
            Console.WriteLine("Сколько нужно было закодировать бит информации: {0}", MessageSize);
            Console.WriteLine("Сколько всего будет информационных бит в закодированном сообщении, то есть значение k: {0}", MessagePartOfCodeSize);
            Console.WriteLine("Сколько всего будет бит в закодированном сообщении, то есть значение n: {0}", CodeSize);
            Console.WriteLine("Сколько всего будет проверочных битов в закодированном сообщении: n - k: {0}", RedundantCheckingPartOfCodeSize);
        }
    }
}
