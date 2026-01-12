namespace StringCalculator.Core
{
    public class StringCalculator
    {
        public int add(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
                return 0;

            string[] partes = input.Split(new char[] {',', '\n' });
            int suma = 0;
            List<int> negativos = new List<int>();
            foreach (var parte in partes) 
            {
                if (int.TryParse(parte, out int numero))
                {
                    if (numero < 0)
                    {
                        negativos.Add(numero);
                    }
                    else if  (numero <= 1000)
                        suma += numero;
                }
            
            }

            if (negativos.Count > 0)
            {
                throw new ArgumentException("números negativos no permitidos: " + string.Join(", ", negativos));
            }
            return suma;
        }

    }
}
