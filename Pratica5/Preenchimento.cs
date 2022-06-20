class Preenchimento
{
    public static void Aleatorio(int[] vet, int limite)
    {
        Random r = new Random();
        for (int i = 0; i < vet.Length; i++)
        {
            vet[i] = r.Next(0, limite);
        }
    }
    public static void Crescente(int[] vet)
    {
        for (int i = 0; i < vet.Length; i++)
        {
            vet[i] = i;
        }
    }
    public static void Decrescente(int[] vet)
    {
        for (int i = vet.Length - 1; i > 0; i--)
        {
            vet[vet.Length - i] = i;
        }
    }
}
