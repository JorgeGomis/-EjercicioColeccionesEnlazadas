using TrabajoGrupal;
class ListaDoblementeEnlazada<T> : IDisposable, IEnumerable<T> where T : IComparable<T>
{
    public NodoListaDoblementeEnlazada<T>? Primero { get; private set; }
    public NodoListaDoblementeEnlazada<T>? Ultimo { get; private set; }
    public int Longitud { get; private set; }
    public bool Vacia => Longitud == 0;
    public ListaDoblementeEnlazada()
    {  
        Primero = Ultimo = null;
        Longitud = 0;
    }
    public ListaDoblementeEnlazada(IEnumerable<T> secuencia)
    {
        Primero = Ultimo = null;
        Longitud = 0;
        
        foreach (T dato in secuencia)
            AñadeAlFinal(dato);
    }
    public void AñadeAlPrincipio(NodoListaDoblementeEnlazada<T> nuevo)
    {
        nuevo.Siguiente = Primero;

        if (Longitud == 0) Ultimo = nuevo;
        else Primero!.Anterior = nuevo;

        Primero = nuevo;

        Longitud++;
    }
    public void AñadeAlPrincipio(T dato)
    {
        NodoListaDoblementeEnlazada<T> nuevo = new NodoListaDoblementeEnlazada<T>(dato);

        nuevo.Siguiente = Primero;

        if (Longitud == 0) Ultimo = nuevo;
        else Primero!.Anterior = nuevo;

        Primero = nuevo;

        Longitud++;
    }
    public void AñadeAlFinal(NodoListaDoblementeEnlazada<T> nuevo)
    {
        nuevo.Anterior = Ultimo;

        if (Longitud == 0) Primero = nuevo;
        else Ultimo!.Siguiente = nuevo;

        Ultimo = nuevo;

        Longitud++;
    }
    public void AñadeAlFinal(T dato)
    {
        NodoListaDoblementeEnlazada<T> nuevo = new NodoListaDoblementeEnlazada<T>(dato);

        nuevo.Anterior = Ultimo;

        if (Longitud == 0) Primero = nuevo;
        else Ultimo!.Siguiente = nuevo;

        Ultimo = nuevo;

        Longitud++;
    }
    public NodoListaDoblementeEnlazada<T>? Busca(T dato) {
        NodoListaDoblementeEnlazada<T>? nodo = Primero;
        while (nodo is not null) {
            if (nodo.Dato.Equals(dato))
                return nodo;
            else
                nodo = nodo.Siguiente;
        }
        return null;
    }
    public void EditaNodo(T datoAnterior, T datoNuevo, string direccion) {
        NodoListaDoblementeEnlazada<T>? nodo = direccion switch {
            "palante" => Primero,
            "patras" => Ultimo,
            _ => null
        };
        while (nodo is not null) {
            if (nodo.Dato.Equals(datoAnterior))
                nodo.Dato = datoNuevo;
            else
                nodo = direccion == "palante" ? nodo.Siguiente : nodo.Anterior;
        }
    }
}