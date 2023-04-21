namespace TrabajoGrupal;
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
    public NodoListaDoblementeEnlazada<T>? Busca(T dato)
    {
        NodoListaDoblementeEnlazada<T>? nodo = Primero;
        while (nodo is not null)
        {
            if (nodo.Dato.Equals(dato))
                return nodo;
            else
                nodo = nodo.Siguiente;
        }
        return null;
    }
    public void EditaNodo(T datoAnterior, T datoNuevo, string direccion)
    {
        NodoListaDoblementeEnlazada<T>? nodo = direccion switch
        {
            "palante" => Primero,
            "patras" => Ultimo,
            _ => null
        };
        while (nodo is not null)
        {
            if (nodo.Dato.Equals(datoAnterior))
                nodo.Dato = datoNuevo;
            else
                nodo = direccion == "palante" ? nodo.Siguiente : nodo.Anterior;
        }
    }
    public void Dispose()
    {
        this.Longitud = 0;
        this.Primero = this.Ultimo = null;
    }
    public void Clear() => Dispose();
    public void GetEnumerator()
    {

    }
    public void AñadeAntesDe(
        NodoListaDoblementeEnlazada<T> nodo,
        NodoListaDoblementeEnlazada<T> nuevo)
    {
        if (this.Primero == nodo)
        {
            this.AñadeAlPrincipio(nuevo);
            return;
        }
        nuevo.Siguiente = nodo;
        nuevo.Anterior = nodo.Anterior;
        nodo.Anterior!.Siguiente = nuevo;
        nodo.Anterior = nuevo;
        this.Longitud++;
    }
    public void AñadeAntesDe(
        NodoListaDoblementeEnlazada<T> nodo,
        T dato)
    {
        if (this.Primero == nodo)
        {
            this.AñadeAlPrincipio(dato);
            return;
        }
        NodoListaDoblementeEnlazada<T> nuevo = new NodoListaDoblementeEnlazada<T>(dato);
        nuevo.Siguiente = nodo;
        nuevo.Anterior = nodo.Anterior;
        nodo.Anterior!.Siguiente = nuevo;
        nodo.Anterior = nuevo;
        this.Longitud++;
    }
    public void AñadeDespuesDe(
        NodoListaDoblementeEnlazada<T> nodo,
        NodoListaDoblementeEnlazada<T> nuevo)
    {
        if (nodo == this.Ultimo)
        {
            this.AñadeAlFinal(nuevo);
            return;
        }
        nodo.Siguiente!.Anterior = nuevo;
        nuevo.Siguiente = nodo.Siguiente;
        nuevo.Anterior = nodo;
        nodo.Siguiente = nuevo;
        this.Longitud++;
    }
    public void AñadeDespuesDe(
        NodoListaDoblementeEnlazada<T> nodo,
        T dato)
    {
        if (nodo == this.Ultimo)
        {
            this.AñadeAlFinal(dato);
            return;
        }
        NodoListaDoblementeEnlazada<T> nuevo = new NodoListaDoblementeEnlazada<T>(dato);
        nodo.Siguiente!.Anterior = nuevo;
        nuevo.Siguiente = nodo.Siguiente;
        nuevo.Anterior = nodo;
        nodo.Siguiente = nuevo;
        this.Longitud++;
    }
}