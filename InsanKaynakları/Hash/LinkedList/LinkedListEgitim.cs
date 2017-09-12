    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynakları.LinkedList
{
    public class LinkedListEgitim : ILinkedList
    {
        public EgitimNode Head;
        public int Size = 0;

        public void DeleteFirst()
        {
            EgitimNode tmpHead = new EgitimNode()
            {
                OkulAdi = "",
                BaslangicTarih = 0,
                BitisTarih = 0,
                Bolum = "",
                Not = 0
            };
            EgitimNode item = Head;
            if (item != null)
            {
                tmpHead = Head.Next;
                Head = tmpHead;
                Size--;
            }

        }

        public void DeleteLast()
        {
            EgitimNode item = Head;
            while (item != null)
            {
                try
                {
                    if (item.Next.Next == null)
                    {
                        item.Next = null;
                        Size--;
                    }
                    item = item.Next;
                }
                catch (Exception)
                {

                    Head = null;
                    Size = 0;
                    break;
                }

            }
        }

        public void DeletePos(int position)
        {

            EgitimNode item = Head;
            int positionCounter = 0;
            while (item != null)
            {
                positionCounter++;
                if (positionCounter == position - 1)
                {
                    item.Next = item.Next.Next;
                }
                else if (position == 1)
                {
                    DeleteFirst();
                    break;
                }

                item = item.Next;
            }

        }

        public string DisplayElements()
        {
            string temp = "";
            EgitimNode item = Head;
            while (item != null)
            {
                temp += " " + item.OkulAdi + " " + item.Bolum + " " + item.BaslangicTarih + " " + item.BitisTarih + " " + item.Not + Environment.NewLine;
                item = item.Next;
            }
            return temp;
        }

        public object GetElement(int position)
        {
            EgitimNode temp = null;
            EgitimNode item = Head;
            int positionCounter = 0;
            while (item != null)
            {
                if (positionCounter == position - 1)
                {
                    temp = item;
                }
                item = item.Next;
                positionCounter++;
            }
            return temp;
        }

        public double GetElementOrt(int position)
        {
            EgitimNode temp = null;
            EgitimNode item = Head;
            int positionCounter = 0;
            while (item != null)
            {
                if (positionCounter == position - 1)
                {
                    temp = item;
                }
                item = item.Next;
                positionCounter++;
            }
            return temp.Not;
        }

        public void InsertFirst(object value)
        {
            //Geçici Başlangıç Kısmı
            EgitimNode tmpHead = new EgitimNode
            {
                OkulAdi = "",
                BaslangicTarih = 0,
                BitisTarih = 0,
                Bolum = "",
                Not = 0
            };

            //Head null ise yani Bağlı listede(LinkedList) eleman yoksa geçici elemanımızı başlangıç elemanımız yapıyoruz.
            if (Head == null)
            {
                Head = tmpHead;
            }
            else
            {
                //Head null değil ise veriyi ezmemek için (Kaybetmemek için) geçici elemanımızın gösterdiği elemanı (Next'i) şu anki başlangıç elemanı yapıyoruz.
                tmpHead.Next = Head;
                //Geçici elemanımızı ise Başlangıç elemanımıza atıyoruz ve veri eklenmiş oluyor.
                Head = tmpHead;
            }
            Size++;

        }

        public void InsertLast(object value)
        {
            //Geçici Elemanımıza gelen value atadık.
            EgitimNode tmpLast = new EgitimNode()
            {
                OkulAdi = "",
                BaslangicTarih = 0,
                BitisTarih = 0,
                Bolum = "",
                Not = 0
            };
            //Bağlı listede gezinmek için EgitimNode tipinde bir item oluşturduk ve Head değerini ona atadık.
            EgitimNode item = Head;
            //Gönderilen ilk eleman bağlı listenin ilk elemanı olma ihtimaline karşı null kontrolü yaptık
            if (item == null)
            {
                // Eğer null ise liste Head'imizi geçici elemanımız yaptık.
                Head = (EgitimNode)value;
            }
            else
            {
                //Eğer null değil ise  döngümüzü başlattık.
                while (item != null)
                {
                    //Bulunduğumuz elemanın next'i null ise son elemandayız demektir. O yüzden bu elemanın Next'ine geçici elemanımızı atarız ve döngüden break komutuyla çıkarız.
                    if (item.Next == null)
                    {
                        item.Next = tmpLast;
                        break;
                    }
                    item = item.Next;

                }
            }

            Size++;
        }

        public void InsertPos(int position, object value)
        {
            int positionCounter = 0;
            EgitimNode tempPos = new EgitimNode()
            {
                OkulAdi = "",
                BaslangicTarih = 0,
                BitisTarih = 0,
                Bolum = "",
                Not = 0
            };

            EgitimNode item = Head;

            if (item == null)
            {
                Head = tempPos;
            }
            else
            {

                while (item != null)
                {

                    positionCounter++;
                    if (positionCounter == position - 1)
                    {
                        tempPos.Next = item.Next;
                        item.Next = tempPos;
                        break;
                    }

                    item = item.Next;

                }
            }
            Size++;
        }

        public bool DeleteValue(object value) { return false; }

    } 


    }

