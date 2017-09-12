using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InsanKaynakları.LinkedList;
using InsanKaynakları.BST;
using InsanKaynakları.Hash;
using InsanKaynakları.Heap;

namespace InsanKaynakları
{
    public partial class frmInsanKaynaklari : Form
    {
        public frmInsanKaynaklari()
        {
            InitializeComponent();
        }

        KisiIkiliAramaAgaci Kisiler = new KisiIkiliAramaAgaci();

        SirketIkiliAramaAgaci Sirketler = new SirketIkiliAramaAgaci();

        BasvuruHash basvurular=new BasvuruHash();

        private void frmInsanKaynaklari_Load(object sender, EventArgs e)
        {
            

            EgitimNode egitim = new EgitimNode();
            egitim.OkulAdi = "FATİH SULTAN MEHMET LİSESİ";
            egitim.Not = 65;
            egitim.Bolum = "Sayısal";
            egitim.BaslangicTarih = 2008;
            egitim.BitisTarih = 2012;
            IsDeneyimiNode deneyim = new IsDeneyimiNode();
            deneyim.Ad = "Pisano Yazılım";
            deneyim.Adres = "Levent/İstanbul";
            deneyim.Gorev = "Yazılım Test Mühendisi";
            deneyim.Pozisyon= "Testing";
            Aday aday = new Aday();
            aday.Adi = "Furkan Kafa";
            aday.Adres = "ZEYTİNBURNU";
            aday.DogumTarih = "1985";
            aday.DogumYeri = "SİİRT";
            aday.E_Posta = "furkankafa@gmail.com";
            aday.YabanciDil = "İngilizce";
            Kisiler.Ekle(aday, egitim, deneyim);

            EgitimNode egitim2 = new EgitimNode();
            egitim2.OkulAdi = "HÜSEYİN NİHAL ATSIZ LİSESİ";
            egitim2.Not = 92;
            egitim2.Bolum = "EŞİT AĞIRLIK";
            egitim2.BaslangicTarih = 2011;
            egitim2.BitisTarih = 2015;
            IsDeneyimiNode deneyim2 = new IsDeneyimiNode();
            deneyim2.Ad = "HAVELSAN";
            deneyim2.Adres = "ANKARAA";
            deneyim2.Gorev = "WEB TEKNOLOJİLERİ";
            deneyim2.Pozisyon = "Backend Developer";
            Aday aday2 = new Aday();
            aday2.Adi = "Engin Kadir";
            aday2.Adres = "BAKIRKÖY";
            aday2.DogumTarih = "1990";
            aday2.DogumYeri = "RİZE";
            aday2.E_Posta = "enginkafa@gmail.com";
            aday2.YabanciDil = "Fransızca";
            Kisiler.Ekle(aday2, egitim2, deneyim2);


            EgitimNode egitim3 = new EgitimNode();
            egitim3.OkulAdi = "METEHAN ANADOLU LİSESİ";
            egitim3.Not = 99;
            egitim3.Bolum = "SAYISAL";
            egitim3.BaslangicTarih = 2009;
            egitim3.BitisTarih = 2013;
            IsDeneyimiNode deneyim3 = new IsDeneyimiNode();
            deneyim3.Ad = "MICROSOFT";
            deneyim3.Adres = "ATAŞEHİR/İSTANBUL";
            deneyim3.Gorev = "Office geliştiricisi";
            deneyim3.Pozisyon = "UYGULAMA GELİŞTİRİCİ";
            Aday aday3 = new Aday();
            aday3.Adi = "Ramazan Deniz";
            aday3.Adres = "FATİH/İSTANBUL";
            aday3.DogumTarih = "1992";
            aday3.DogumYeri = "MANİSA";
            aday3.E_Posta = "ramazandeniz@gmail.com";
            aday3.YabanciDil = "İngilizce";
            Kisiler.Ekle(aday3, egitim3, deneyim3);

            Sirket sirketBilgileri1 = new Sirket();
            sirketBilgileri1.Telefon = "0212-312-23-45";
            sirketBilgileri1.Faks = "0212-312-23-45";
            sirketBilgileri1.Eposta = "pisano@gmail.com";
            sirketBilgileri1.Adres = "Levent/İstanbul";
            sirketBilgileri1.Adi = "Pisano Yazılım";
            IsIlani ilan1 = new IsIlani();
            ilan1.IsTanimi = "JAVA DEVELOPMENT";
            ilan1.ArananOzellikler = "JAVA EE hakim olan, yazılım mimarisi ve kalıplarına aşina takım arkadaşları arıyoruz.";
            ilan1.BasvuruSayi = Convert.ToInt32("10");
            Sirketler.Ekle(sirketBilgileri1, ilan1);


            Sirket sirketBilgileri2 = new Sirket();
            sirketBilgileri2.Telefon = "0212-333-12-45";
            sirketBilgileri2.Faks = "0212-333-12-45";
            sirketBilgileri2.Eposta = "horizon@gmail.com";
            sirketBilgileri2.Adres = "Şişli-Perpa İş Merkezi/İstanbul";
            sirketBilgileri2.Adi = "Horizon Yazılım";
            IsIlani ilan2 = new IsIlani();
            if (ilan1.IlanNo==ilan2.IlanNo)
            {
                Random rast = new Random();
                ilan2.IlanNo = rast.Next(0,1000);
            }
            ilan2.IsTanimi = ".Net Uygulama Geliştiricisi";
            ilan2.ArananOzellikler = " .Net teknolojilerine hakim, iyi derecede ingilizcebilen iş arkadaşları arıyoruz.";
            ilan2.BasvuruSayi = Convert.ToInt32("20");
            Sirketler.Ekle(sirketBilgileri2, ilan2);

            KisiGoster();
            dataGoster();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Kişisel Bilgilerini Tutalım...
            Aday kisiselBilgileriDugumu = new Aday();
            kisiselBilgileriDugumu.Adi = txtAd.Text;
            kisiselBilgileriDugumu.Adres = txtAdres.Text;
            //kisiselBilgileriDugumu.DogumTarih=txtd
            kisiselBilgileriDugumu.DogumYeri = txtDogumYeri.Text;
            kisiselBilgileriDugumu.E_Posta = txtEposta.Text;
            kisiselBilgileriDugumu.IlgiAlanlari = txtIlgiAlanlari.Text;
            kisiselBilgileriDugumu.MedeniDurum = txtMedeniDurum.Text;
            kisiselBilgileriDugumu.Referans = txtReferansBilgileri.Text;
            kisiselBilgileriDugumu.Telefon = txtTelefon.Text;
            kisiselBilgileriDugumu.Uyruk = txtUyruk.Text;
            kisiselBilgileriDugumu.YabanciDil = txtYabanciDil.Text;
            
            //Eğitim Bilgilerini Tutalım...
            EgitimNode egitimBilgileriDugumu = new EgitimNode();
            egitimBilgileriDugumu.OkulAdi = txtOkulAdi.Text;
            egitimBilgileriDugumu.Not =Convert.ToDouble(txtNotOrtalamasi.Text);
            egitimBilgileriDugumu.Bolum = txtBolumu.Text;
            egitimBilgileriDugumu.BaslangicTarih = Convert.ToInt32(txtBaslangicTarihi.Text);
            egitimBilgileriDugumu.BitisTarih = Convert.ToInt32(txtBitisTarihi.Text);
            
            //İşyeri Bilgilerini Tutalım...
            IsDeneyimiNode isyeriBilgileriDugumu = new IsDeneyimiNode();
            isyeriBilgileriDugumu.Ad = txtIsyeriAdi.Text;
            isyeriBilgileriDugumu.Pozisyon = txtPozisyon.Text;
            isyeriBilgileriDugumu.Adres = txtIsyeriAdres.Text;


            Kisiler.Ekle(kisiselBilgileriDugumu, egitimBilgileriDugumu, isyeriBilgileriDugumu);

            //dataGoster();
            KisiGoster();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //Kişisel Bilgilerini Tutalım...
            Aday kisiselBilgileriDugumu = new Aday();
            //kisiselBilgileriDugumu.Adi = txtAd.Text;
            kisiselBilgileriDugumu.Adres = txtAdres.Text;
            //kisiselBilgileriDugumu.DogumTarih=txtd
            kisiselBilgileriDugumu.DogumYeri = txtDogumYeri.Text;
            kisiselBilgileriDugumu.E_Posta = txtEposta.Text;
            kisiselBilgileriDugumu.IlgiAlanlari = txtIlgiAlanlari.Text;
            kisiselBilgileriDugumu.MedeniDurum = txtMedeniDurum.Text;
            kisiselBilgileriDugumu.Referans = txtReferansBilgileri.Text;
            kisiselBilgileriDugumu.Telefon = txtTelefon.Text;
            kisiselBilgileriDugumu.Uyruk = txtUyruk.Text;
            kisiselBilgileriDugumu.YabanciDil = txtYabanciDil.Text;
            //BinarySearchTree Guncelle Methodu çağırılıyor...
            Kisiler.Guncelle(txtAd.Text, kisiselBilgileriDugumu, null, null);
            KisiGoster();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Kisiler.Sil(txtAd.Text);
            KisiGoster();
        }

        private void KisiGoster()
        {
            comboboxKisi.Items.Clear();
            foreach (var eleman in Kisiler.Kisiler())
            {
                comboboxKisi.Items.Add(eleman.AdayBilgileri.Adi);
            }
        }

        private void btnSKaydet_Click(object sender, EventArgs e)
        {
            Sirket sirketBilgileri = new Sirket();
            sirketBilgileri.Telefon = txtSTelefon.Text;
            sirketBilgileri.Faks = txtSFaks.Text;
            sirketBilgileri.Eposta = txtSEposta.Text;
            sirketBilgileri.Adres = txtSAdres.Text;
            sirketBilgileri.Adi = txtSAdi.Text;
            IsIlani ilan = new IsIlani();
            ilan.IsTanimi = txtSIsTanimi.Text;
            ilan.ArananOzellikler = txtSAranan.Text;
            ilan.BasvuruSayi = Convert.ToInt32( txtBasvuruSayi.Text);
            Sirketler.Ekle(sirketBilgileri,ilan);
            dataGoster();
        }

        private void btnSGuncelle_Click(object sender, EventArgs e)
        {
            Sirket sirketBilgileri = new Sirket();
            sirketBilgileri.Telefon = txtSTelefon.Text;
            sirketBilgileri.Faks = txtSFaks.Text;
            sirketBilgileri.Eposta = txtSEposta.Text;
            sirketBilgileri.Adres = txtSAdres.Text;
            IsIlani ilan = new IsIlani();
            ilan.IsTanimi = txtSIsTanimi.Text;
            ilan.ArananOzellikler = txtSAranan.Text;
            Sirketler.Guncelle(txtSAdi.Text, sirketBilgileri);
            dataGoster();

        }

        private void btnSSil_Click(object sender, EventArgs e)
        {
            Sirketler.Sil(txtSAdi.Text);
            dataGoster();
        }
        List<SirketNode> ilanlar = new List<SirketNode>();
        //Datagridview'e tüm iş ilanlarını ekleme.
        private void dataGoster()
        {
           //ilanlar listesi temizleniyor.
            ilanlar.Clear();
            //Sirketler ikiliaramağacındaki tüm iş ilanları geri döndürülüyor.
            ilanlar = Sirketler.IsIlanlari();
            int sayac = 0;
            //Datagridview tüm elemanlar temizleniyor.
            GridViewIsBasvuruları.Rows.Clear();
            int ilanSayisi = 0;
            foreach (var sirket in ilanlar)
            {
                ilanSayisi = sirket.Size;
                for (int i = 0; i < ilanSayisi; i++)
                {
                    GridViewIsBasvuruları.Rows.Add();//datagridviewe yeni satır ekler            
                         
                    GridViewIsBasvuruları.Rows[sayac].Cells[0].Value = sirket.SirketBilgileri.Adi.ToString();
                    GridViewIsBasvuruları.Rows[sayac].Cells[1].Value = sirket.IsIlanlari[i].IlanNo.ToString();     GridViewIsBasvuruları.Rows[sayac].Cells[2].Value = sirket.IsIlanlari[i].IsTanimi.ToString();
                    GridViewIsBasvuruları.Rows[sayac].Cells[3].Value = sirket.IsIlanlari[i].ArananOzellikler.ToString();
                    sayac++;
                }
            

            }
            
            
        }

        private void tabIsBasvuru_Click(object sender, EventArgs e)
        {

        }

        private void GridViewIsBasvuruları_DoubleClick(object sender, EventArgs e)
        {

           txtIsyeri.Text=GridViewIsBasvuruları.CurrentRow.Cells["SirketAdi"].Value.ToString();
            txtBoxIlanNo.Text = GridViewIsBasvuruları.CurrentRow.Cells["IlanNo"].Value.ToString();
        }

        private void btnBasvur_Click(object sender, EventArgs e)
        {
            //ADAY İSMİNE GÖRE BİLGİLERİ AL
            KisiNode kisi = new KisiNode();
            kisi=Kisiler.AdaGoreAra(comboboxKisi.Text);
            //SİRKET İSMİNE GÖRE BİLGİLERİ AL
            SirketNode sirket = new SirketNode();
            sirket=Sirketler.Ara(txtIsyeri.Text);
            //HASHTABLE İÇİNDE TUT

            try
            {
                MessageBox.Show((basvurular.IlanBasvuru(Convert.ToInt32(txtBoxIlanNo.Text), kisi, sirket)) == true ? "İLAN BAŞVURUSU BAŞARILI" : "İLAN BAŞVURUSU BAŞARISIZ");
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString());
                MessageBox.Show("HATALI FİRMA VE KİŞİ SEÇİMİ");
            }
            finally
            {
                IseBasvuranlar();
            }
            
        }

        //İşe  başvuranları gridview de gösterme.
        private void IseBasvuranlar()
        {
            gridViewIsBasvurulari.Rows.Clear();
            BasvuruNode[] BasvuruListesi = new BasvuruNode[1000];
            BasvuruListesi = basvurular.AllGetBasvurular();
            int sayac = 0;
            foreach (var eleman in BasvuruListesi)
            {
                if (eleman==null)
                {
                    continue;
                }
                int basvuranSayisi = eleman.BasvuranKisiler.CurrentSize;
                for (int i = 0; i < basvuranSayisi; i++)
                {
                    gridViewIsBasvurulari.Rows.Add();
                    BasvuranlarNode[] basvuranlar = eleman.BasvuranKisiler.GetAllBasvuranlar();
                    gridViewIsBasvurulari.Rows[sayac].Cells[0].Value = basvuranlar[i].KisiBilgileri.AdayBilgileri.Adi;
                    gridViewIsBasvurulari.Rows[sayac].Cells[1].Value = eleman.IlanNo.ToString();
                    gridViewIsBasvurulari.Rows[sayac].Cells[2].Value = eleman.IsyeriBilgileri.SirketBilgileri.Adi;
                    gridViewIsBasvurulari.Rows[sayac].Cells[3].Value = basvuranlar[i].IseUygunluk.ToString();
                    sayac++;
                  
                }

            }
        }

        private void btnAdayIseAl_Click(object sender, EventArgs e)
        {
            string text= basvurular.UygunKisiSec().ToString();
            if (text != "")
                richListeleme.Text += "\t\tUygun Kişileri Seçme\n" + text;
            else
                richListeleme.Text = "Başvuru Yok";
        }

        private void btnIsmeGoreBilgiListeleme_Click(object sender, EventArgs e)
        {
            KisiNode Aranan = new KisiNode();
            Aranan= Kisiler.AdaGoreAra(txtIsmeGoreAra.Text);
            if (Aranan == null)
            { richListeleme.Text = "Aranan Kişi Yok"; return; }
            richListeleme.Text += 
                "\t\tİsme Göre Arama\n" 
                + "Adı:"+Aranan.AdayBilgileri.Adi
                +" \nAdresi:"+Aranan.AdayBilgileri.Adres
                +"\nDoğum Tarihi: "+Aranan.AdayBilgileri.DogumTarih
                +"\nDoğum Yeri:"+Aranan.AdayBilgileri.DogumYeri+"\nEposta:"
                +Aranan.AdayBilgileri.E_Posta
                +"\nİlgi Alanları:"+Aranan.AdayBilgileri.IlgiAlanlari
                +"\nMedeni Durum: "+Aranan.AdayBilgileri.MedeniDurum
                +"\nReferans: "+Aranan.AdayBilgileri.Referans
                +"\nTelefon: "+Aranan.AdayBilgileri.Telefon
                +"\nUyruk"+Aranan.AdayBilgileri.Uyruk
                +"Yabancı Dil: "+Aranan.AdayBilgileri.YabanciDil+"\n";

        }

        private void btnIngilizceListeleme_Click(object sender, EventArgs e)
        {

           
            
            richListeleme.Text +="\n\t\tİngilizce Bilenler"+ Kisiler.DileGoreAra();

        }

        private void btnOrtalamaListeleme_Click(object sender, EventArgs e)
        {
            richListeleme.Text +="\n\t\tOrtalaması 90'DAN yüksek olanlar"+ Kisiler.OrtalamaGoreAra();
        }

        private void btnAgacDerinlikveElemanSayısını_Click(object sender, EventArgs e)
        {
            Kisiler.PreOrder();
            richListeleme.Text += Kisiler.dugumler;
            Kisiler.InOrder();
            richListeleme.Text += Kisiler.dugumler;
            Kisiler.PostOrder();
            richListeleme.Text += Kisiler.dugumler;
        }

        private void btnTumunuListele_Click(object sender, EventArgs e)
        {
            richListeleme.Text = "ELEMAN SAYISI:" + Kisiler.ElemanSayisi();
        }
    }
}
