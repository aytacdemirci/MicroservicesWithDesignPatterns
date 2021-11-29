Mikroservis mimarisi’nde servislerin birbirine olan bağımlılığını minimize edebilmek (loose coupling)

Gevşek bağlı (loosely coupled) servisler ile;
 - Bir servisin çalışmadığı durumda diğer servislerin çalışmaya devam edebilmesi,
 - Bir serviste yapılan değişikliğin diğer servisleri etkilememesi,
 - Servislerin kolay bir şekilde test edilebilmesi,
 - Ölçeklemenin kolaylaşması
 - gibi kritik faydalar elde ederiz.

Olay güdümlü mimari (event-driven architecture), loosely coupled servisler geliştirmemiz için kullandığımız yöntemlerden birisi.

Yöntem, sistemde yapılan değişikliklerin olaylar (events) şeklinde ortak bir platforma, bir message broker’a, 
yayımlanıp bu değişikliklerin tüketilmesi üzerine kurulu. 
X servisindeki bir işlem, Y servisini çağıracağına, yaptığı işlemi message broker’da yayımladıktan sonra (publishing), 
bu olaya abone olan Y servisi (subscriber), olayı yakalayıp yapması gereken işi yapıyor (consuming). 
Bu sayede bu iki servisin birbirine olan bağımlılığını ortadan kaldırmış oluyoruz.

Fakat burada şöyle bir sorunla karşılaşabiliriz: Eğer X servisi kendi tarafındaki işleri tamamladıktan sonra Y’nin yapması gereken iş için 
gerekli event’i yollayamaz ise, mesela message broker servisi ayakta değilse, işlem yarım kalmış, veri bütünlüğü sağlanamamış olur.
İşte burada yazımızın konusu olan “transactional outbox pattern” devreye giriyor. Bu pattern ile çok basit bir ifade ile X servisinin yaptığı işlem 
ve göndereceği event bir transactional bütünlük içerisinde gerçekleştiriliyor. 
Eğer event gönderilirken bir sorun ile karşılaşılır ise tüm işlem geri sarılıyor. Bu sayede veri bütünlüğünü sağlamış oluyoruz. 
Ayrıca artık X servisinin event’i yayımlayacağı platforma olan bağımlılığı da ortadan kaldırılmış oluyor. 
Message broker’ın ayakta olup olmadığı artık X’i ilgilendirmiyor.

 servisi gerekli veri tabanı işlemlerini yaptıktan sonra direkt olarak message broker ile iletişime geçmek yerine event’lerin 
 tutulduğu başka bir tabloya kayıt atıyor. Bu şekilde X servisi tüm bu işlemi bir transactional bütünlükte yapabiliyor. 
 Diğer yandan ise bir message relay(Worker Service), tabloya yazılan bu event’leri alıp message broker’a yolluyor. 
 İşlem başarılı ise event’lerin gönderildiğine dair tablodaki kayıtları güncelliyor.