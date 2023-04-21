namespace TrabajoGrupal;

public class NodoListaDoblementeEnlazada<T> : IDisposable where T : IComparable<T>
{
    public NodoListaDoblementeEnlazada<T>? Anterior { get; set; }
    public NodoListaDoblementeEnlazada<T>? Siguiente { get; set; }
    public T Dato { get; set; }
    public NodoListaDoblementeEnlazada(T dato)
    {
        Dato = dato;
        Anterior = Siguiente = null;
    }

    public void Dispose()
    {
        Dato = default(T);
        Anterior = null;
        Siguiente = null;
    }
    public override string ToString()
    {
        string Anterior = this.Anterior is null ? "" : $"[{this.Anterior.Dato}]";
        string Siguiente = this.Siguiente is null ? "" : $"[{this.Siguiente.Dato}]";
        return $"{Anterior}[{this.Dato}]{Siguiente}";
    }
}