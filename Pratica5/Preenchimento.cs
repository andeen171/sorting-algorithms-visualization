class Preenchimento {
    public static void Aleatorio(int[] vet, int limite) {
        Random r = new Random();
        for (int i = 0; i < vet.Length; i++) {
            vet[i] = r.Next(0, limite);
        }
    }
    public static void Crescente(int[] vet, int limite) {
        for (int i = 0; i < limite; i++)
        {
            vet[i] = i + 1;
        }
    }
    public static void Decrescente(int[] vet, int limite) {
        for (int i = limite; i > 0; i--)
        {
            vet[i] = i - 1;
        }
    }
}
