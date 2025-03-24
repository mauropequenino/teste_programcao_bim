using System;

string numPredefinidos = "00080000901900583004301000740015000300270401008009600070006300030070080904500001";
int[,] matriz = gerarMatriz(numPredefinidos);

Console.WriteLine("MATRIZ VAZIA\n");
exibirMatriz(matriz);


Console.WriteLine("------------------------------------------------------------------------\n");
Console.WriteLine("MATRIZ PREENCHIDA\n");

string substituirZeros = "2563714724686925678923965851327418429565914228376";

int[,] matrizPreenchida = preencherMatriz(matriz, substituirZeros);

exibirMatriz(matrizPreenchida);

Console.WriteLine();

verificarMatriz(matrizPreenchida);


static int[,] gerarMatriz(string insercoes)
{
    int[,] matriz = new int[9, 9];

    int aux = 0;

    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            
            if (aux < insercoes.Length)
            {
                //Converter o char para int
                matriz[i, j] = insercoes[aux] - '0';
                aux++;
            }
        }
    }
    return matriz;
}

static void exibirMatriz(int[,] matriz) 
{
    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            Console.Write(matriz[i, j]);

            if (j < 8)
            {
                Console.Write("\t");
            }
        }
        Console.WriteLine();
    }
}

static bool verificarLinhaHorizontal(int[,] matriz, int linha)
{
    bool[] numeros = new bool[10];

    for (int j = 0; j < 9; j++)
    {
        int valor = matriz[linha, j];

        // verificar se valor esta fora do intervalo e se esta repetido
        if (numeros[valor]) 
        {
            Console.Write($"Linha:{linha+1} - Numero: {valor}  | "); ;
            return false;
            
        }

        numeros[valor] = true;
    }

    return true;
}

static bool verificarColunaVertical(int[,] matriz, int coluna)
{
    bool[] numeros = new bool[10]; 

    for (int i = 0; i < 9; i++)
    {
        int valor = matriz[i, coluna];

        // verificar se valor esta fora do intervalo e se esta repetido
        if (numeros[valor]) 
        {
            Console.Write($"Coluna:{coluna+1} - Numero: {valor} | ");
            return false; 
        }
          
        numeros[valor] = true;
    }

    return true;
}

static void verificarMatriz(int[,] matriz) 
{
    for(int i = 0; i < 9; i++)
    {
        if (!verificarColunaVertical(matriz, i)) 
        {
            Console.WriteLine("A coluna verifical contem um numero repetido");
        }
    }

    for(int j = 0; j < 9; j++) 
    {
        if (!verificarLinhaHorizontal(matriz, j))
        {
            Console.WriteLine("A linha horizontal contem um numero repetido");
        }
    }
}

static int[,] preencherMatriz(int[,] matriz, string insercoes)
{
    int aux = 0;

    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
        {

            if (aux < insercoes.Length)
            {
                if (matriz[i, j] == 0) 
                
                {
                    matriz[i, j] = insercoes[aux] - '0';
                    aux++;
                }
            }
        }
    }
    return matriz;
}




