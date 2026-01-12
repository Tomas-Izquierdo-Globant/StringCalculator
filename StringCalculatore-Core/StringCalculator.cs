namespace StringCalculator.Core
{
    public class StringCalculator
    {
        public int add(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
                return 0;

            string[] partes = input.Split(',');
            int suma = 0;
            foreach (var parte in partes) 
            {
                if (int.TryParse(parte, out int numero))
                {
                    suma += numero;
                } else {
                    suma += 0;
                }
            
            }
            return suma;
        }

    }
}
