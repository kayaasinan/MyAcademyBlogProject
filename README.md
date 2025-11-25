# 📝 BLOGY – AI-Destekli Multi-Panel Blog Yönetim Sistemi
### 🧠 Modern, Çok Katmanlı & Yapay Zekâ Destekli Blog Platformu

BLOGY, kullanıcıların blog içeriklerini okuduğu; yazarların içerik oluşturduğu; yöneticilerin kategoriler, yorumlar ve kullanıcıları yönettiği,
AI moderasyon, AI öneri motoru, Generic Repository Pattern, FluentValidation, AutoMapper ve ASP.NET Core 8.0 teknolojileriyle geliştirilmiş çok panelli (Admin–Writer–Member) bir blog yönetim sistemidir.

### 📌 Proje Hakkında

BLOGY, güncel yazılım prensiplerine göre geliştirilmiş, N-Katmanlı Mimariye sahip, hızlı, güvenli ve modern bir blog yönetim platformudur.
Üç farklı rolün yönetildiği gelişmiş bir panel yapısı sunar:

🛡️ Admin Paneli → Kullanıcı, kategori, blog, yorum ve sistem yönetimi,istatistikleri görüntüleme alanı,rol atama işlemmleri vb.

✍️ Writer Paneli → Yazarların blog oluşturma, düzenleme, profil sayfaları

👤 Member Paneli → Üyelerin profil yönetimi, yorum yapabilme, blog okuma deneyimi

🎯 Öne çıkan en büyük farkı:
OpenAI entegrasyonuyla desteklenen otomatik yorum moderasyonu + AI öneri motoru ve Chatbox.
Sistemdeki yorumlar, OpenAI Moderation modeliyle otomatik olarak analiz edilir, böylece platform güvenli ve kaliteli içerik akışı sağlar.
Ayrıca sistem, okunan bloga göre AI tabanlı içerik önerileri sunar ve admin ile canlı olarak iletişime geçilebilir.

| Katman / Alan             | Teknoloji / Araçlar |
|---------------------------|----------------------|
| 🧩 Backend               | ASP.NET Core MVC (.NET 8.0) |
| 🗄️ ORM                  | Entity Framework Core (Code First) |
| 🧠 Mimari                | N-Katmanlı Mimari, Generic Repository Pattern |
| 🔐 Kimlik                | ASP.NET Core Identity (Admin / Writer / Member) |
| 🧾 Doğrulama            | FluentValidation, DataAnnotations |
| 🔄 Dönüşüm              | AutoMapper (Profile Mapping) |
| 🤖 Yapay Zekâ           | OpenAI Moderation API (Toxicity), AI Suggestion Engine |
| 🎨 Arayüz               | Bootstrap 5, jQuery, FontAwesome, SweetAlert |
| 🧰 Veri Tabanı          | SQL Server |
| 🧩 UI Yapısı            | ViewComponents, Partial Views Layouts |
| 🔧 Katmanlar-Arası DI   | Built-in Dependency Injection Container |
| 🔒 Güvenlik / Bot Koruma | Google reCAPTCHA v3 |

## 📷 Ekran Görüntüleri
---
##  Ana Sayfa
**📌 Ana Sayfa** 

![HomePage](https://github.com/kayaasinan/MyAcademyBlogProject/blob/master/Blogy.WebUI/wwwroot/images/homapage.png?raw=true) 

**📌 Hakkımızda** 

![About](https://github.com/kayaasinan/MyAcademyBlogProject/blob/master/Blogy.WebUI/wwwroot/images/about.png?raw=true) 

**📌 Blog** 

![Blog](https://github.com/kayaasinan/MyAcademyBlogProject/blob/master/Blogy.WebUI/wwwroot/images/blog.png?raw=true) 

**📌 Blog Detayları** 

![BlogDetails](https://github.com/kayaasinan/MyAcademyBlogProject/blob/master/Blogy.WebUI/wwwroot/images/blogdetail1.png?raw=true) 

![BlogDetails](https://github.com/kayaasinan/MyAcademyBlogProject/blob/master/Blogy.WebUI/wwwroot/images/blogdetail2.png?raw=true) 

**📌 Chatbox** 

![Chatbox](https://github.com/kayaasinan/MyAcademyBlogProject/blob/master/Blogy.WebUI/wwwroot/images/ai-chatbox.png?raw=true) 

##  Admin Paneli

**📌 Dashboard** 

![Dashboard](https://github.com/kayaasinan/MyAcademyBlogProject/blob/master/Blogy.WebUI/wwwroot/images/dashboard.png?raw=true) 

**📌 Bloglar** 

![Blog](https://github.com/kayaasinan/MyAcademyBlogProject/blob/master/Blogy.WebUI/wwwroot/images/admin%20blog.png?raw=true) 

**📌 Yorumlar** 

![Comment](https://github.com/kayaasinan/MyAcademyBlogProject/blob/master/Blogy.WebUI/wwwroot/images/admin%20comment.png?raw=true) 

**📌 Kullanıcılar** 

![User](https://github.com/kayaasinan/MyAcademyBlogProject/blob/master/Blogy.WebUI/wwwroot/images/user.png?raw=true) 

**📌 AI- Makale** 

![ai-article](https://github.com/kayaasinan/MyAcademyBlogProject/blob/master/Blogy.WebUI/wwwroot/images/ai-article.png?raw=true) 

**📌 Sosyal Meyda** 

![Social](https://github.com/kayaasinan/MyAcademyBlogProject/blob/master/Blogy.WebUI/wwwroot/images/admin%20social.png?raw=true) 






