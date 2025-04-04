using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        
    }
}

//i semafori saranno gestiti a coppie di due, dove una coppia sarà verde e una coppia sarà rossa

class Semaforo
{
    public Semaforo(bool? statoIniziale, int tempoAttesa)
    {
        statoSemaforo = statoIniziale;
        attesa = tempoAttesa;
    }
    public bool? statoSemaforo = null; // true = verde, false = rosso

    public int attesa; // tempo di attesa in millisecondi

    public bool? cambio(int attesa)
    {
        if (statoSemaforo == true)
        {
            Thread.Sleep(attesa); // attesa in millisecondi
            statoSemaforo = false;
        }
        else if (statoSemaforo == false)
        {
            Thread.Sleep(attesa); // attesa in millisecondi
            statoSemaforo = true;
        }
        return statoSemaforo;
    }
}


//la classe è fatta prendendo come riferimento un incrocio a 4 strade, con 1 semaforo per strada 
class incrocio
{
    public Semaforo semaforo1;
    public Semaforo semaforo2;
    public Semaforo semaforo3;
    public Semaforo semaforo4;

    public bool controlloSemafori(incrocio incrocio)
    {
        bool? stato1 = incrocio.semaforo1.statoSemaforo;
        
        bool? stato2 = incrocio.semaforo2.statoSemaforo;
        
        bool? stato3 = incrocio.semaforo3.statoSemaforo;
        
        bool? stato4 = incrocio.semaforo4.statoSemaforo;

        if (stato1 == false && stato3 == false)
        {
            if (stato2 == true)
            {
                if (stato4 == true)
                {
                    Console.WriteLine("sono tutti verdi, aspetta un attimo");
                    incrocio.semaforo1.cambio(incrocio.semaforo1.attesa); // attesa in millisecondi
                    incrocio.semaforo2.cambio(incrocio.semaforo2.attesa); // attesa in millisecondi
                    incrocio.semaforo3.cambio(incrocio.semaforo3.attesa); // attesa in millisecondi
                    incrocio.semaforo4.cambio(incrocio.semaforo4.attesa); // attesa in millisecondi
                    
                }
            }
        }
        if (stato2 == false && stato4 == false)
        {
            if (stato1 == true)
            {
                if (stato3 == true)
                {
                    Console.WriteLine("sono tutti verdi, aspetta un attimo");
                    incrocio.semaforo4.cambio(incrocio.semaforo4.attesa); // attesa in millisecondi
                    
                }
            }
        }
        else
        {
            return false; // almeno un semaforo è di stato diverso
        }
    }
}