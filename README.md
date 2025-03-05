# BaseCoffee

BaseCoffee, C# dilinde geliştirilmiş bir yazılım çözümüdür. Bu proje, özellikle İş Mantığı Katmanı (BLL) ve Veri Erişim Katmanı (DAL) kullanarak uygulama geliştirme sürecini daha modüler ve sürdürülebilir hale getirmeyi hedefler. Proje, katmanlı mimariyi benimseyerek yazılımın bakımını ve genişletilmesini kolaylaştırır.

## Özellikler
- **İş Mantığı Katmanı (BLL):** Uygulamanın iş mantığının yönetildiği katmandır. Bu katman, kullanıcı isteklerine göre verileri işleyip doğru sonuçları döndürür.
- **Veri Erişim Katmanı (DAL):** Veritabanı işlemleri için kullanılan katmandır. Veritabanı ile bağlantı, veri sorgulama ve güncelleme işlemleri burada yapılır.
- **Modüler Yapı:** Her bir katman, bağımsız olarak test edilebilir ve geliştirilebilir.
- **Kolay Genişletilebilirlik:** Yeni özellikler eklemek kolaydır, çünkü iş mantığı ve veri erişimi ayrı tutulur.

## Başlarken

Projenin çalışabilmesi için aşağıdaki adımları izleyebilirsiniz:

### Gereksinimler
- **.NET Core 5.0** veya daha yeni bir sürüm
- Visual Studio veya benzeri bir C# geliştirme ortamı

### Projeyi Klonlama
Projenin en son sürümünü yerel makinenize klonlamak için aşağıdaki komutu kullanabilirsiniz:

```bash
git clone https://github.com/Minelka/BaseCoffee.git
```

### Bağımlılıkları Yükleme
Projeyi çalıştırmadan önce gerekli bağımlılıkları yüklemek için aşağıdaki komutu kullanabilirsiniz:

```bash
dotnet restore
```

### Projeyi Çalıştırma
Projeyi çalıştırmak için Visual Studio veya aşağıdaki komut ile .NET CLI kullanabilirsiniz:

```bash
dotnet run
```

## Katkıda Bulunma

Katkıda bulunmak isterseniz, lütfen aşağıdaki adımları takip edin:

1. Repo'yu forklayın.
2. Yeni bir özellik dalı (feature branch) oluşturun.
3. Değişikliklerinizi yapın ve commit edin.
4. Pull request gönderin.

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için [Lisans dosyasına](LICENSE) bakabilirsiniz.

---
