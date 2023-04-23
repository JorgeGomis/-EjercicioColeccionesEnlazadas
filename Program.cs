using TrabajoGrupal;

internal class Program
{
    private static void Main(string[] args)
    {
        ListaDoblementeEnlazada<int> ld = new ListaDoblementeEnlazada<int>();
        ld.AñadeAlPrincipio(4);
        ld.AñadeAlPrincipio(3);
        ld.ImprimeLista();

        ld.Clear();
        ld.AñadeAlFinal(6);
        ld.AñadeAlFinal(9);
        ld.AñadeAlPrincipio(3);
        ld.ImprimeLista();
        
        NodoListaDoblementeEnlazada<int> nodo = ld.Busca(6);
        ld.AñadeAntesDe(nodo, 5);
        ld.AñadeAntesDe(ld.Primero, 1);
        ld.AñadeDespuesDe(nodo, 7);
        ld.AñadeDespuesDe(ld.Ultimo, 12);
        ld.ImprimeLista();

        ld.Borra(nodo);
        ld.Borra(ld.Primero);
        ld.Borra(ld.Ultimo);
        ld.ImprimeLista();

        ld.Clear();
        ld.ImprimeLista();
        
        Console.ReadLine();
    }
}