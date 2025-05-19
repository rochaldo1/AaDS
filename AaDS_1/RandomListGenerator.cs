namespace AaDS_1
{
    public class RandomListGenerator
    {
        private Random random;

        public RandomListGenerator()
        {
            random = new Random();
        }

        /// <summary>
        /// Метод для генерации списка чисел.
        /// </summary>
        /// <param name="start">Число от которого генерируются числа.</param>
        /// <param name="end">Число до которого генерируются числа</param>
        /// <param name="count">Количество чисел в списке.</param>
        /// <param name="uniqueness">Уникальность:
        /// 2 - в списке только уникальные числа
        /// 1 - в списке числа могут повторяться (редко, 10%)
        /// 0 - в списке числа могут повторяться (часто, 50%)
        /// -1 - в списке числа одинаковые</param>
        /// <returns>Список сгенерированных чисел</returns>
        /// <exception cref="ArgumentException"></exception>
        public List<int> GenerateList(int start, int end, int count, int uniqueness)
        {
            List<int> list = new List<int>();

            if (uniqueness == 2)
            {
                HashSet<int> uniqueNumbers = new HashSet<int>();
                while (uniqueNumbers.Count < count)
                {
                    int number = random.Next(start, end + 1);
                    uniqueNumbers.Add(number);
                }
                list.AddRange(uniqueNumbers);
            }
            else if (uniqueness == 1)
            {
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(start, end + 1);
                    list.Add(number);
                    if (random.NextDouble() < 0.1) // 10% вероятность повтора
                    {
                        list.Add(number);
                    }
                }
            }
            else if (uniqueness == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(start, end + 1);
                    list.Add(number);
                    if (random.NextDouble() < 0.5) // 50% вероятность повтора
                    {
                        list.Add(number);
                    }
                }
            }
            else if (uniqueness == -1)
            {
                int number = random.Next(start, end + 1);
                for (int i = 0; i < count; i++)
                {
                    list.Add(number);
                }
            }
            else
            {
                throw new ArgumentException("Invalid uniqueness parameter");
            }

            return list;
        }
    }
}
