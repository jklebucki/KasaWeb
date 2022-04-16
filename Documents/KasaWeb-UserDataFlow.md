**KasaWeb** 

Licencjonowanie odbywa się na zasadzie zakupu subskrypcji oraz licencji dla nazwanych użytkowników.

**Przepływ danych użytkownika**

Nadrzędnym użytkownikiem jest administrator aplikacji AA, ponadto w systemie istnieje administrator grupy firm (AGF) (jeden lub wielu), który jest dodany przez AA.

AGF rejestruje nowych użytkowników, a system powiadamia ich o zarejestrowaniu.

Użytkownicy są nazwani. 

Jeden użytkownik może mieć uprawniania do wielu lokalizacji w obrębie grupy firm, a co za tym idzie do wielu firm – uprawnienia te przyznaje AGF.

Użytkownik po zalogowaniu się widzi listę lokalizacji do których ma dostęp i wybiera w której lokalizacji będzie tworzył dokumenty.

W obrębie lokalizacji użytkownik posiada jedną z trzech roli:

- **user**: zwykły użytkownik wprowadzający dokumenty i generujący wydruki/raporty
- **superuser**: posiada prawa te same co user oraz dodatkowo może zmieniać podstawowe konfirguracje takie jak konta księgowe, symbole dokumentów itp.
- **admin**: może robić wszystko w obrębie organizacji z pełną świadomością konsekwencji jakie niosą za sobą określone rodzaje zamian.

Wszyscy użytkownicy, również AA i AGF, mają też rolę w obrębie aplikacji.

- **user**: zwykły użytkownik przypisywany do lokalizacji
- **superuser**: posiada prawa te same co user oraz dodatkowo może rejestrować innych użytkowników w roli **user** i **superuser** w obrębie aplikacji.  
- **admin**: może robić wszystko w obrębie aplikacji z pełną świadomością konsekwencji jakie niosą za sobą określone rodzaje zamian.

Dzięki temu mamy jedną stałą listę ról która pozwala na definiowanie ról zarówno użytkowników aplikacji jak i lokalizacji.
