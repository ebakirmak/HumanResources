using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynakları.LinkedList
{
    public class LinkedListIsDeneyimi:ILinkedList
    {
        public IsDeneyimiNode Head;
        public int Size = 0;

        public void DeleteFirst()
        {
            IsDeneyimiNode tmpHead = new IsDeneyimiNode()
            {
                Ad = "",
                Adres = "",
                Gorev = "",
                Pozisyon = ""

            };
            IsDeneyimiNode item = Head;
            if (item != null)
            {
                tmpHead = Head.Next;
                Head = tmpHead;
                Size--;
            }

        }

        public void DeleteLast()
        {
            IsDeneyimiNode item = Head;
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

            IsDeneyimiNode item = Head;
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
            IsDeneyimiNode item = Head;
            while (item != null)
            {
                temp += " " + item.Ad + " " + item.Adres + " " + item.Gorev + " " + item.Pozisyon + Environment.NewLine;          
                item = item.Next;
            }
            return temp;
        }

        public object GetElement(int position)
        {
            IsDeneyimiNode temp = null;
            IsDeneyimiNode item = Head;
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

        public void InsertFirst(object value)
        {
            //Geçici Başlangıç Kısmı
            IsDeneyimiNode tmpHead = new IsDeneyimiNode
            {
                Ad = "",
                Adres = "",
                Gorev = "",
                Pozisyon = ""
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
            IsDeneyimiNode tmpLast = new IsDeneyimiNode()
            {
                Ad = "",
                Adres = "",
                Gorev = "",
                Pozisyon = ""
            };
            //Bağlı listede gezinmek için IsDeneyimiNode tipinde bir item oluşturduk ve Head değerini ona atadık.
            IsDeneyimiNode item = Head;
            //Gönderilen ilk eleman bağlı listenin ilk elemanı olma ihtimaline karşı null kontrolü yaptık
            if (item == null)
            {
                // Eğer null ise liste Head'imizi geçici elemanımız yaptık.
                Head = (IsDeneyimiNode)value;
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
            IsDeneyimiNode tempPos = new IsDeneyimiNode()
            {
                Ad = "",
                Adres = "",
                Gorev = "",
                Pozisyon = ""
            };

            IsDeneyimiNode item = Head;

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

        /*  public bool DeleteValue(int value)
          {
              IsDeneyimiNode item = Head;
              bool sonuc = false;
              if (item.OkulAdi == value)
              {
                  sonuc = true;
                  if (item.Next != null)
                  {
                      Head = item.Next;
                      item = Head;

                  }
                  else
                  {
                      Head = null;
                  }

              }


              while (item.Next != null)
              {

                  if (item.Next != null)
                  {
                      if (item.Next.OkulAdi == value)
                      {
                          sonuc = true;
                          if (item.Next.Next != null)
                              item.Next = item.Next.Next;
                          else
                              item.Next = null;

                      }
                      else
                      {
                          item = item.Next;
                      }

                  }




              }
              return sonuc;



          }
          */
    }
}
