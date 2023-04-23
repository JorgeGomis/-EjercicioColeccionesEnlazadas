using System.Collections;
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

    public IEnumerator<T> GetEnumerator() => new Enumerador(Primero);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    private class Enumerador : IEnumerator<T>, IDisposable {
        private NodoListaDoblementeEnlazada<T>? It {get; set;}
        private NodoListaDoblementeEnlazada<T>? Primero {get; set;}
        public Enumerador(NodoListaDoblementeEnlazada<T> primero) {
            Primero = primero;
            Reset();
        }
        public void Reset() => It = null;
        public T Current => It!.Dato;
        object IEnumerator.Current => Current;
        public bool MoveNext() {
            bool puedoIterar = It == null && Primero != null || It != null && It.Siguiente != null;
            if (puedoIterar) It = It == null ? Primero : It.Siguiente;
            return puedoIterar;
        }
        public void Dispose() {
            Primero = null;
            It = null;
        }
    }
    public void ImprimeLista(){
        IEnumerator<T> e1 = GetEnumerator();
        while (e1.MoveNext())
        {
            Console.Write($"{e1.Current} "); 
        }
    }
    public void Borra(NodoListaDoblementeEnlazada<T> nodo)
    {
        if (Longitud == 1)
        {     
            Primero = Ultimo = null;
        }
        else if (Primero == nodo)
        {
            Primero = nodo.Siguiente;
            nodo.Siguiente.Anterior = null;
        }
        else
        {
            NodoListaDoblementeEnlazada<T>? a = null;
            for (NodoListaDoblementeEnlazada<T>? n = Primero; n != null && n != nodo; n = n.Siguiente) a = n;

            if (a == null)
                throw new Exception("El nodo a borrar no pertenece a la lista.");

            a.Siguiente = nodo.Siguiente;
            if (Ultimo == nodo)
                Ultimo = a;
        }
        
        nodo.Siguiente = nodo.Anterior = null;
        
        Longitud--;
    }
}