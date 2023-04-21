namespace TrabajoGrupal;

public class NodoListaDoblementeEnlazada<T> : IDisposable where T : IComparable<T> {
    public NodoListaDoblementeEnlazada<T>? Anterior {get; set;}
    public NodoListaDoblementeEnlazada<T>? Siguiente {get; set;}
    public T Dato { get; private set;}
    public NodoListaDoblementeEnlazada(T dato) {
        Dato = dato;
        Anterior = Siguiente = null;
    }

    public void Dispose() {
        Dato = default(T);
        Anterior = null;
        Siguiente = null;
    }
}   