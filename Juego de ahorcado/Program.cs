class Ahorcado
{
    static void Main()
    {
        // Este es un arreglo de palabras (palabras[]) que contiene las palabras secretas que el jugador tiene que adivinar en el juego.
        string[] palabras = { "manzana", "guineo", "jirafa", "Iphone", "Computadora", "programacion" };

        // Este es arreglo bidimensional de pistas (pistas[,]) contiene pistas para cada palabra secreta. Cada fila del arreglo corresponde a una palabra, y las columnas contienen diferentes pistas sobre esa palabra.
        string[,] pistas = {
            { "Es una fruta", "Es roja o verde", "Es redonda", "Crece en un palo", "Es de color verde al principio" },
            { "Es una fruta amarilla", "Es larga", "Es dulce", "Es amarilla cuando esta madura", "Se pela antes de comercelo" },
            { "Es un animal", "Es de cuello largo", "Vive en africa", "Tiene manchas en su piel", "Es un herbívoro" },
            { "Es un dispositivo mobil", "Tiene una pantalla grande", "Se utiliza para llamar", "Puede ser muy caro", "Tiene una manzana" },
            { "Es una maquina", "Tiene una pantalla", "Se usa para programar", "Es esencial en la oficina", "Puede ser portatil o de escritorio" },
            { "Es una actividad", "Involucra escribir codigo", "Es parte del desarrollo de software", "Requiere logica", "Es muy popular en el campo tecnologico" }
        };
        //Aquí use la clase Random para elegir una palabra de manera aleatoria y rand.Next(0, palabras.Length) para selecciona un índice aleatorio entre 0 y el número de palabras disponibles en el arreglo.
        Random rand = new Random();
        int indicePalabra = rand.Next(0, palabras.Length);
        string palabraSecreta = palabras[indicePalabra];
        //puse este arreglo palabraMostrar[] que se inicializa con guiones bajos (_), uno por cada letra de la palabra secreta que ya conto length. Esto es lo que el jugador verá al principio, antes de adivinar ninguna letra.
        string[] palabraMostrar = new string[palabraSecreta.Length];//este es es un arreglo que contiene las letras correctamente adivinadas y los guiones bajos (_) para las letras no adivinadas.
        for (int i = 0; i < palabraMostrar.Length; i++) palabraMostrar[i] = "_";//aqui el for lo use para empezar el bucle y que empiece a contar y recorrer la palabra a mostar o sea lo que esta almacenado en la variable que tiene como limite el valos que conto lenght 

        int intentosRestantes = 6; // guarde en esta variable el maximo de intentos que tiene el jugador
        int intentosFallidos = 0; //esto lo use para las pistas o sea el numero de intentos fallidos y lo inicia a contar en 0

        Console.WriteLine("¡Bienvenido al juego del Ahorcado!");
        Console.WriteLine("Tienes 6 intentos para adivinar la palabra secreta.");
        Console.WriteLine("Adivina una letra en cada intento.");

        while (intentosRestantes > 0) //El bucle se va seguir ejecutando mientras tenfa intentos restantes o sea sea mayor que 0
        {
            Console.Clear();//Esto limpia la pantalla para mostrar una nueva ronda esto va mostrar los datos actualizados
            Console.WriteLine("Palabra: " + string.Join(" ", palabraMostrar));//aqui muestra el estado actual
            Console.WriteLine("Intentos restantes: " + intentosRestantes);// esto muestra cuántos intentos le quedan al jugador antes de perder.
            Console.WriteLine("Pistas: " + pistas[indicePalabra, intentosFallidos]);//aqui imprime las pistas que tiene el arreglo en la posicion de la coordenada

            Console.Write("Introduce una letra: ");
            char letra = Char.ToLower(Console.ReadKey().KeyChar);//esto se usa para capturar la tecla que el jugador presiona
            Console.WriteLine();// Solo agrega una linea en blanco

            // Cprueba si la letra esta dentro de la palabra secreta
            bool acierto = false;//Use un buliano para cierto o falso
            for (int i = 0; i < palabraSecreta.Length; i++)//El bucle for recorre todas las letras de la palabra secreta
            {
                if (palabraSecreta[i] == letra)
                {
                    palabraMostrar[i] = letra.ToString();// Esto lo convierte a string
                    acierto = true;
                }
            }

            // Si no acerto, restamos un intento
            if (!acierto)
            {
                intentosRestantes--;//aqui con le va restanto
                intentosFallidos++;//aqui suma 
            }

            // aqui comprueba si el jugador  adivino la palabra
            if (string.Join("", palabraMostrar) == palabraSecreta)
            {
                Console.Clear();
                Console.WriteLine("¡Ganaste! La palabra secreta es: " + palabraSecreta);
                break;
            }

            // aqui mira si se quedo sin intentos
            if (intentosRestantes == 0)
            {
                Console.Clear();
                Console.WriteLine("Perdiste. La palabra secreta era: " + palabraSecreta);
            }
        }
    }
}