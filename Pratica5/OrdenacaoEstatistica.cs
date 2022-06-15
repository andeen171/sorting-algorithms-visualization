class OrdenacaoEstatistica {
    // TODO: contador de comparações e trocas
    // TODO: declarar demais métodos de ordenação
    public static int cont_c, cont_t;
    public static void Bolha(int[] vet) {
        int i, j, temp;
        for (i = 0; i < vet.Length - 1; i++) {
            for (j = vet.Length - 1; j > i; j--) {
                cont_c++;
                if (vet[j] < vet[j - 1]) {
                    temp = vet[j];
                    vet[j] = vet[j - 1];
                    vet[j - 1] = temp;
                    cont_t++;
                }
            }
        }
    }
}
    