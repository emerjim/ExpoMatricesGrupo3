/*
Sección A - Algoritmos - Grupo #3.

Nombres:                                # de Carnet:
Emerson Alejandro Jiménez Torres        9989-21-20811
Hugo Alexander Domínguez Castellanos    9989-16-12969
Marco Antonio Rodriguez Aguirre         9989-19-63
Gerson Fernando Ixtecoc Pérez           9989-22-3276
Elvin Eduardo Muralles Melgar           9989-22-5053
Jorge David Gatica García               9989-22-128
*/
using System;
using System.IO;

public class Program
{
    public static void Main ()
    {

        //Bienvenida al programa y detalle de lo que hará.
        Console.WriteLine("Bienvenido a la exposición de Matrices - GRUPO #3");
        Console.WriteLine("");
        Console.WriteLine("El programa realizará lo siguiente: ");
        Console.WriteLine("Creará un arreglo multidimensional con un tamaño que definiremos nosotros por teclado, ");
        Console.WriteLine("contendrá números aleatorios usando la función rellenaArray y crearemos ");
        Console.WriteLine("un arreglo unidimensional donde se copiaran los números que contiene el arreglo multidimensional, ");
        Console.WriteLine("e imprimirá este en un archivo de texto.");
        Console.WriteLine("");
        
        //Declaracion de variables y arreglos
        int opc = 0; 
        int[,] arregloMulti = null;
        int[] arregloUnid = null;
        
        //Creación y nombre del StreamWriter
        StreamWriter escritor = null;

        Console.WriteLine("Presiona cualquier tecla para continuar y desplegar el menú.");
        Console.ReadKey();

        do {
            Console.Clear();
            Console.WriteLine("««« EJERCICIO DE MATRICES - GRUPO #3 »»»");
            Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
            Console.WriteLine("1. Definir el tamaño del Arreglo Multidimensional");
            Console.WriteLine("2. Rellenar el Arreglo Multidimensional aleatoriamente");
            Console.WriteLine("3. Visualizar los números de los Arreglos: Multidimensional y Unidimensional");
            Console.WriteLine("4. Crear y rellenar el archivo .txt");
            Console.WriteLine("5. Eliminar el archivo .txt");
            Console.WriteLine("6. SALIR.");

            opc= Convert.ToInt32(Console.ReadLine());

            switch(opc)
            {
                case 1:
                    //Declaración de las variables
                    int filas = 0; 
                    int columnas = 0;
                    int size = 0;
                    
                    //Establecer el tamaño de arreglo Multidimensional
                    Console.WriteLine("Para empezar, definir el tamaño del Arreglo Multidimensional: ");        
                    Console.WriteLine("Ingresa la cantidad de filas: ");
                    filas = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa la cantidad de columnas: ");
                    columnas = Convert.ToInt32(Console.ReadLine());

                    arregloMulti = new int[filas, columnas];

                    Console.WriteLine("Listo, tamaño del Arreglo Multidimensional definido.");
                    
                    //Establecer el tamaño de arreglo Unidimensional
                    size = Convert.ToInt32((filas*columnas));
                    Console.WriteLine("Además, se creo un arreglo Unidimensional con tamaño: " + size);

                    arregloUnid = new int[size];
                    break;
                case 2:
                    rellenaArray(arregloMulti, arregloUnid);
                    break;
                case 3:
                    verArrays(arregloMulti,arregloUnid);
                    break;
                case 4:
                    crearTxt(escritor);
                    escribirTxt(escritor, arregloMulti, arregloUnid);

                    break;
                case 5:
                    eliminarTxt(escritor);
                    break;
                case 6:
                    Console.WriteLine("Saliendo... gracias por utilizar este programa.");
                    break;
                default:
                    Console.WriteLine("La opción ingresada no es valida, selecciona una opción del menú.");
                    break;
            }
            Console.ReadKey();
        }while (opc !=6);

 
    }
    
    //métodos utilizados.
    public static void rellenaArray(int[,] arregloMulti, int[] arregloUnid){
        int filas = arregloMulti.GetLength(0); 
        int columnas = arregloMulti.GetLength(1); 
        
        

        // llenar aleatoreamente la matriz
        Random aleatorio = new Random();
        for (int i = 0; i < filas; i++) //filas
        {
            for (int j = 0; j < columnas; j++) //columnas
            {
                arregloMulti[i,j] = aleatorio.Next(1,100);
            }
        }
        Console.WriteLine("Listo, arreglo Multidimensional rellenado aleatoriamente (con números del 1 al 100).");
    }

    public static void verArrays(int[,] arregloMulti, int[] arregloUnid){
        int filas = arregloMulti.GetLength(0); 
        int columnas = arregloMulti.GetLength(1);

        //Impresión del arreglo Multidimensional
        Console.WriteLine("");
        Console.WriteLine("«««««« ARREGLO MULTIDIMENSIONAL »»»»»»");
        Console.WriteLine("");
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                Console.Write(arregloMulti[i,j] + "\t");
            }
            Console.WriteLine("");
        }
        
        Console.WriteLine("");
        Console.WriteLine("El arreglo convertido a Unidimensional se muestra así: ");
        Console.WriteLine("");
        
        //Impresión del arreglo Unidimensional
        Console.WriteLine("");
        Console.WriteLine("«««««« ARREGLO UNIDIMENSIONAL »»»»»»");
        Console.WriteLine("");
        
        int indice = 0; 
        
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                Console.WriteLine("Posición [" + indice + "]: " + arregloMulti[i,j]);
                indice = indice+1;
            }     
        }
            Console.WriteLine("");
        
    }

    public static void crearTxt(StreamWriter escritor)
    {
        escritor = new StreamWriter("./archivo.txt");
        escritor.Close();
        Console.WriteLine("El archivo de texto (.txt) ha sido creado.");
    }
    public static void escribirTxt(StreamWriter escritor, int[,] arregloMulti, int[] arregloUnid)
    {
        escritor = new StreamWriter("./archivo.txt");
        int filas = arregloMulti.GetLength(0); 
        int columnas = arregloMulti.GetLength(1);
        
        //Impresión del arreglo Unidimensional
        escritor.WriteLine("");
        escritor.WriteLine("«««««« ARREGLO UNIDIMENSIONAL »»»»»»");
        escritor.WriteLine("");

        int indice = 0; 
        
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                escritor.WriteLine("Posición [" + indice + "]: " + arregloMulti[i,j]);
                indice = indice+1;
            }     
        }
            escritor.WriteLine("");

        // Aqui se cierra
        escritor.Close();
        Console.WriteLine("El archivo de texto (.txt) ha sido rellenado (o actualizado).");
    }
      public static void eliminarTxt(StreamWriter escritor){
        File.Delete("./archivo.txt");
        Console.WriteLine("El archivo de texto (.txt) ha sido eliminado.");

    }
    
}