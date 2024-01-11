# ~~Погані~~ Хороші практики розробки джем-гри в Unity

> ~~Worst~~ Best Development Practices of jam game in Unity

# Вступ

Мабуть ви чули про таку штуку як Best Practices (Хороші Практики) програмування. [SOLID](https://uk.wikipedia.org/wiki/SOLID_(%D0%BE%D0%B1%27%D1%94%D0%BA%D1%82%D0%BD%D0%BE-%D0%BE%D1%80%D1%96%D1%94%D0%BD%D1%82%D0%BE%D0%B2%D0%B0%D0%BD%D0%B5_%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D1%83%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F)), [патерни](https://uk.wikipedia.org/wiki/%D0%A8%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD%D0%B8_%D0%BF%D1%80%D0%BE%D1%94%D0%BA%D1%82%D1%83%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F_%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BD%D0%BE%D0%B3%D0%BE_%D0%B7%D0%B0%D0%B1%D0%B5%D0%B7%D0%BF%D0%B5%D1%87%D0%B5%D0%BD%D0%BD%D1%8F), [DRY (Don’t Repeat Yourself)](https://uk.wikipedia.org/wiki/Don%27t_repeat_yourself) - ці гарно сформульовані абревіатури і красиві слова є невід’ємною частиною сучасного світу програмування. “Як це, ти не знаєш, що таке [Abstract Factory](https://uk.wikipedia.org/wiki/%D0%90%D0%B1%D1%81%D1%82%D1%80%D0%B0%D0%BA%D1%82%D0%BD%D0%B0_%D1%84%D0%B0%D0%B1%D1%80%D0%B8%D0%BA%D0%B0), і про [Chain of Responsibility](https://uk.wikipedia.org/wiki/%D0%9B%D0%B0%D0%BD%D1%86%D1%8E%D0%B6%D0%BE%D0%BA_%D0%B2%D1%96%D0%B4%D0%BF%D0%BE%D0%B2%D1%96%D0%B4%D0%B0%D0%BB%D1%8C%D0%BD%D0%BE%D1%81%D1%82%D0%B5%D0%B9) не чув? Як тоді ти хочеш закодити гру?”

Нюанс у тому, що мало хто згадує чому ці практики виникли, згадують лише, що треба їх знати, щоб писати “хороший” код. Але що це таке - цей “хороший” код? І ось тут починаються спекуляції. Тому в мене є свій суб'єктивний спосіб визначення "якості" коду, який трохи перегукується з ідеями [Джеральда Вайнберга](https://uk.wikipedia.org/wiki/%D0%94%D0%B6%D0%B5%D1%80%D0%B0%D0%BB%D1%8C%D0%B4_%D0%92%D0%B0%D0%B9%D0%BD%D0%B1%D0%B5%D1%80%D0%B3), який визначив [чотири цілі, яким повинна відповідати хороша програма](https://en.wikipedia.org/wiki/Coding_best_practices). Він полягає в тому, що набагато важливіше не те чи код хороший, а чи гра/програма:

1) Дає очікуваний результат
2) Реалізує ту поведінку, яка задумана
3) Чи написана вона вчасно (тобто чи є ще актуальною ця гра/програма)

**В рамках геймджему мабуть саме час має найбільшу роль, тому на цьому і потрібно зосереджувати свої зусилля.**

### Ключові моменти

То що ж можна зробити, щоб уникнути великих затрат часу при написанні гри. На мою думку, тут важливо ось що:

**1.  Швидке додавання чи заміна компонентів/логіки.**
 - **1.2. Поліморфізм**

**2.  Швидка комунікація між компонентами/системами.**
- **2.1. GameHub.One**
- **2.2. Game Events**

**3.  Уникнення рефакторингу**

**4.  Уникнення/швидкий фікс багів (принаймні критичних)**

**5.  Додаткові поради**

---
## 1. Швидке додавання чи заміна компонентів/логіки

### 1.1 Поліморфізм

Припустимо в нашій грі є різні об'єкти, з якими треба взаємодіяти в грі і ця взаємодія різна для різних об'єктів. Наприклад, книжку можна прочитати, а ключ - підібрати в Інвентар. А може ми книжку теж захочемо підібрати? 
Спочатку нам знадобиться простенький інтерфейс *IInteractable* і дві його реалізації *Readable* та *Pickable*:

    public interface IInteractable
    {
        public void Interact();
    }

    public class Readable : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log($"Read {gameObject.name}");
        }
    }
    
    public class Pickable : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log($"Picked up {gameObject.name}");
        }
    }
    
Тепер потрібен контролер гравця, який, коли дотикається (collide) до якогось предмета, викликає відповідний метод взаємодії.

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<IInteractable>(out var interactable))
        {
            interactable.Interact();
        }
    }

Структура Higherarcy в UnityEditor виглядає ось так:
![Interaction Demo UnityEditor Hierarchy](https://www.dropbox.com/scl/fi/ozqp3xon2pr4l1zcec6ed/interaction_demo_hierarchy.png?rlkey=hgcp1d996l65ngln4eoq9jk97&raw=1)
 
Завдяки цьому простенькому трюку ми тепер можемо:
- Якщо ми захочемо підняти книжку, то потрібно просто замінити компонент *Readable* на *Pickable*
- Додати новий предмет для взаємодії - просто обраємо поведінку з нашого набору реалізацій *IInteractable*.
- Якщо хочемо спробувати якийсь іншу логіку підбирання предмета, але не хочемо втрачати попередню, то робимо нову реалізацію, наприклад *PickableWithEffect*

Щоб трохи розширити наші можливості, то можна в метод Interact додати посилання на гравця, який викликав взаємодію:

    public class Pickable : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemData _data;
    
        public void Interact(PlayerController player)
        {
            Debug.Log($"Picked up {gameObject.name}");
            player.PickupItem(_data);
        }
    }

---
## 2.  Швидка комунікація між компонентами/системами.


### 2.1 GameHub.One

Тут нам допоможе **Singleton**. [Singleton](https://uk.wikipedia.org/wiki/%D0%9E%D0%B4%D0%B8%D0%BD%D0%B0%D0%BA_%28%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD_%D0%BF%D1%80%D0%BE%D1%94%D0%BA%D1%82%D1%83%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F%29) - страшне слово в програмуванні. Це ніби і патерн, але багато хто вважає його [Антипатерном](https://uk.wikipedia.org/wiki/%D0%90%D0%BD%D1%82%D0%B8%D0%BF%D0%B0%D1%82%D0%B5%D1%80%D0%BD). А все тому, що його використання часто порушує [Single Responsibility Principle](https://uk.wikipedia.org/wiki/%D0%9F%D1%80%D0%B8%D0%BD%D1%86%D0%B8%D0%BF_%D1%94%D0%B4%D0%B8%D0%BD%D0%BE%D1%97_%D0%B2%D1%96%D0%B4%D0%BF%D0%BE%D0%B2%D1%96%D0%B4%D0%B0%D0%BB%D1%8C%D0%BD%D0%BE%D1%81%D1%82%D1%96) (S в SOLID), а якщо ще глибше копнути, то він порушує принцип [Cлабкої Зв'язності](https://uk.wikipedia.org/wiki/%D0%97%D0%B2%27%D1%8F%D0%B7%D0%BD%D1%96%D1%81%D1%82%D1%8C_%28%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D1%83%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F%29). Чому це важливо? Та тому що, якщо є одне місце, на яке зав'язано багато інших частин системи (сильна зв'язність), то важко щось змінювати в системі і дуже легко створити баги, які важко виловлювати.

Але, він має і переваги, які дуже важливі, коли обмаль часу. Ця перевага - можна швидко використовувати різні частини системи. В геймдеві *Singleton* використовують у випадках, коли якась частина системи використовується майже всюди і вона існує в одному екземплярі (звідси і назва Singleton - Одинак). Наприклад для AudioSystem, PurchaseSystem, PersistenceSystem.

Рекомендую завжди мати під рукою, якусь реалізацію Singleton і використовувати її в різних проєктах. Ось простий приклад:

    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T One { get; protected set; }

        protected void Awake()
        {
            if (One != null && One != this)
            {
                Destroy(gameObject);
                return;
            }

            One = this as T;
            DontDestroyOnLoad(this);
	        Init();
	    }

	    public virtual void Init()
	    {
	    }
    }

В інтернеті можна знайти безліч пояснень роботи цього патерна, наприклад тут [Singleton · Game Programming Patterns](https://gameprogrammingpatterns.com/singleton.html). Поясню лише навіщо нам тут [Generics](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics) (ось така штучка < T > в першому рядку). Це потрібно для того, щоб ми могли швидко зробити будь-який GameObject синглтоном (приклад буде нижче).

Особисто я звик мати лише один *Singleton* в проєкті з кількома компонентами, щоб не доводилось думати, які ж я там назви попридумував для систем, а також, щоб будь- яку з цих систем можна було легко вивести з категорії одинаків. Для цього я використовую назву **GameHub** (придумав собі її, бо вона відносно коротка, хоча може і ще хтось так її називає). Тепер, коли мені треба звернутись до якоїсь системи я просто пишу GameHub.One.[назва системи]. Покажу приклад реалізації та використання:

    public class GameHub : Singleton<GameHub>
    {
        public GameEventSystem Events { get; private set; }
        public GamePersistenceSystem Storage { get; private set; }
        public IAudioSystem Audio { get; private set; }
    
        public bool IsInitialized { get; private set; }
    
        public override void Init()
        {
            Events = new GameEventSystem();
            Storage = new GamePersistenceSystem();
    
            if (TryGetComponent(out IAudioSystem audioSystem))
            {
                Audio = audioSystem;
            }
    
            IsInitialized = true;
        }
    
        private void OnDisable()
        {
            IsInitialized = false;
        }
    }
-------------
    public void Interact(IPlayer player)
    {
       GameHub.One.Audio.Tracks.UseItem.PlayOneShot();
    }
    
Треба обов'язково додати цей компонент на сцену і все - наш GameHub ініціалізується в Awake та буде доступний всім об'єктам. В прикладі можна побачити, що деякі системи інстанціюються як прості класи через new, а от *Audio* через *TryGetComponent*. Це тому, що нам часто достатньо звичайного C# класу, щоб виконувати якусь логіку, але іноді потрібен і MonoBehaviour, якщо його налаштування потребує інфраструктури Unity (серіалізація в інспекторі, Instantiate, Coroutines - це все не можна використовувати в звичайному класі). В Unity Editor трохи важко працювати з інтерфейсами, які реалізовують класи з MonoBehaviour - наші будівельні блоки гри. Тому, якщо ми хочемо "вкидати" потрібну реалізацію інтерфейсу, то тут є декілька підходів:

- Якщо є гроші, то [Odin Inspector and Serializer](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041) має власну логіку серіалізації, яка дозволяє підкидувати компоненти в “поля-інтерфейси” інспектора. 
- Можна реалізувати власний спосіб такої серіалізації.
- Ну і напевне найпростіший та найшвидший спосіб - це використовувати [TryGetComponent](https://docs.unity3d.com/ScriptReference/Component.TryGetComponent.html) (або трохи гірший варіант [GameObject.GetComponent](https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html)). Цей варіант ми і використали при ініціалізації GameHub.

Ось як виглядає GameHub в Unity Editor:

![GameHub UnityEditor Hierarchy](https://www.dropbox.com/scl/fi/zmsa8hx4mk8ixwk6vl0ff/GameHub.png?rlkey=iv5kq0obtx512zg3yvb2n3w71&raw=1)

---
### 2.2. GameEvents

Якщо ж нам не хочеться робити компонент загальнодоступним, але треба повідомляти глобально про зміни у ньому, то можна використати Game Events. Є дуже багато варіантів реалізації цієї системи і вона дуже часто використовується в програмуванні (EventBus, MessageBus, [EventQueue](https://gameprogrammingpatterns.com/event-queue.html)). В мене ж є дуже проста реалізація цієї системи. Хоч в ній є трохи своїх мінусів (особливо якщо проєкт великий), але нам тут важлива простота і зручність використання. Отже, зараз опишу її.

Тут мені теж подобається використовувати GameHub, оскільки ці події теж глобальні. Все що нам потрібно для початку це два прості класи *GameEventSystem* та *SimpleGameEvent*. Ну і не забути додати поле в GameHub.

    public class GameEventSystem
    {
        public SimpleGameEvent OpenInventory { get; private set; }

        public GameEventSystem()
        {
            OpenInventory = new SimpleGameEvent();
        }

        public class SimpleGameEvent
        {
            private event Action _onEvent;

            public void Notify()
            {
                _onEvent?.Invoke();
            }

            public void Subscribe(Action handler) => _onEvent += handler;
            public void Unsubscribe(Action handler) => _onEvent -= handler;
        }
    }
	
	---   
    
    public class GameHub : Singleton<GameHub>
    {
        public GameEventSystem Events { get; private set; }
		
		...
    }

Клас *GameEventSystem* просто містить колекцію наших глобальних подій. А от *SimpleGameEvent* трохи цікавіший. Ми звісно могли б одразу визначити наші events в GameEventSystem, але додаткова абстракція у вигляді класу-обгортки над базовим event дає нам певні переваги, наприклад передавання і обробка певних даних, контроль над підпискою/відпискою тощо.
Використовувати цю систему доволі просто. Компонент, який хоче повідомити про зміни викликає Notify конкретної події, а компоненти, які хочуть дізнатись про ці зміни викликають Subscribe (ну і Unsubscribe, щоб зберігати систему чистою). Приклад такий: потрібно відкривати Інвентар (*Inventory*), коли гравець взаємодіє з верстаком для крафту (*CraftStation*)

    public class CraftStationEntity : MonoBehaviour, IInteractable
    {
        public void Interact(PlayerController player)
        {
            GameHub.One.Events.OpenInventory.Notify();
            Debug.Log("Crafting!");
        }
    }
    
	---
	
	public class Inventory : MonoBehaviour
    {
        private void Start()
        {
            GameHub.One.Events.OpenInventory.Subscribe(Open);
        }

        private void OnDestroy()
        {
            if (GameHub.One.IsInitialized)
            {
                GameHub.One.Events.OpenInventory.Unsubscribe(Open);
            }
        }

        private void Open()
        {
            Debug.Log("Inventory opened!");
        }
    }


---
## 3. Уникнення рефакторингу

Пусто

---
## 4. Уникнення/швидкий фікс багів (принаймні критичних)

Пусто

---
## 5.  Додаткові поради

### Намагайтесь уникати вкладення префабів

### Використовуте PlayerPrefs

### Використовуйте один AssemblyDefinition

Не використовуйте AssemblyDefinition взагалі (ну і namespaces) або використовуйте лише по-одному AssemblyDefinition для ігрової логіки та для Editor скриптів (бо Edtior-скрипти мають бути в папці Editor)

## P.S.

Щось з того, що я тут розповів не бажано використовувати в комерційних геймдев проєктах, а щось цілком підійде. Можливо, вам якісь підходи чи код видалися неправильними чи недовершеними. І, можливо, ви будете мати рацію, але я не мав на меті описати best practices, як їх подають у підручниках, а швидше запропонувати те, що, на мою думку, працює коли треба швидко зробити гру на гейм-джемі чи запилити прототипчик. Ну і звісно, якщо у вас є пропозиції чи зауваження по цій темі, я б зрадістю з вами їх обговорив, наприклад в discord-спільноті [Ігровари](https://discord.com/invite/igrovari-747455818097623040).
Взагалі, якщо б я міг обрати підхід в розробці, який мені найбільше подобається (але якого я далеко не завжди дотримуююсь) - це [KISS (Keep it short and simple)](https://uk.wikipedia.org/wiki/%D0%9F%D1%80%D0%B8%D0%BD%D1%86%D0%B8%D0%BF_%C2%ABKISS%C2%BB) - "роби просто і коротко" і ускладнюй систему лише, коли це потрібно, бо інакше можна застрягнути в постійному переписуванні/покращенні і забути про головне:

> "Створити цікаву гру можна, якщо тобі її цікаво розробляти".
