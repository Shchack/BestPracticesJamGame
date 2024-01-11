# ~~Погані~~ Хороші практики розробки джем-гри в Unity

> ~~Worst~~ Best Development Practices of jam game in Unity


Мабуть ви чули про таку штуку як Best Practices (Хороші Практики) програмування. [SOLID](https://uk.wikipedia.org/wiki/SOLID_(%D0%BE%D0%B1%27%D1%94%D0%BA%D1%82%D0%BD%D0%BE-%D0%BE%D1%80%D1%96%D1%94%D0%BD%D1%82%D0%BE%D0%B2%D0%B0%D0%BD%D0%B5_%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D1%83%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F)), [патерни](https://uk.wikipedia.org/wiki/%D0%A8%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD%D0%B8_%D0%BF%D1%80%D0%BE%D1%94%D0%BA%D1%82%D1%83%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F_%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BD%D0%BE%D0%B3%D0%BE_%D0%B7%D0%B0%D0%B1%D0%B5%D0%B7%D0%BF%D0%B5%D1%87%D0%B5%D0%BD%D0%BD%D1%8F), [DRY (Don’t Repeat Yourself)](https://uk.wikipedia.org/wiki/Don%27t_repeat_yourself) - ці гарно сформульовані абревіатури і красиві слова є невід’ємною частиною сучасного світу програмування. “Як це, ти не знаєш, що таке [Abstract Factory](https://uk.wikipedia.org/wiki/%D0%90%D0%B1%D1%81%D1%82%D1%80%D0%B0%D0%BA%D1%82%D0%BD%D0%B0_%D1%84%D0%B0%D0%B1%D1%80%D0%B8%D0%BA%D0%B0), і про [Chain of Responsibility](https://uk.wikipedia.org/wiki/%D0%9B%D0%B0%D0%BD%D1%86%D1%8E%D0%B6%D0%BE%D0%BA_%D0%B2%D1%96%D0%B4%D0%BF%D0%BE%D0%B2%D1%96%D0%B4%D0%B0%D0%BB%D1%8C%D0%BD%D0%BE%D1%81%D1%82%D0%B5%D0%B9) не чув? Як тоді ти хочеш закодити гру?”

Нюанс у тому, що мало хто згадує чому ці практики виникли, згадують лише, що треба їх знати, щоб писати “хороший” код. Але що це таке - цей “хороший” код? І ось тут починаються спекуляції. Тому в мене є свій суб'єктивний спосіб визначення "якості" коду, який трохи перегукується з ідеями [Джеральда Вайнберга](https://uk.wikipedia.org/wiki/%D0%94%D0%B6%D0%B5%D1%80%D0%B0%D0%BB%D1%8C%D0%B4_%D0%92%D0%B0%D0%B9%D0%BD%D0%B1%D0%B5%D1%80%D0%B3), який визначив [чотири цілі, яким повинна відповідати хороша програма](https://en.wikipedia.org/wiki/Coding_best_practices). Він полягає в тому, що набагато важливіше не те чи код хороший, а чи гра/програма:

1) Дає очікуваний результат
2) Реалізує ту поведінку, яка задумана
3) Чи написана вона вчасно (тобто чи є ще актуальною і її реалізація вкладається в терміни)

**В рамках геймджему мабуть саме час має найбільшу роль, тому на цьому і потрібно зосереджувати свої зусилля.**

То що ж можна зробити, щоб уникнути великих затрат часу при написанні гри. На мою думку, тут важливо ось що.

## Ключові моменти

[1. Додавання чи заміна компонентів чи логіки](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#1-%D0%B4%D0%BE%D0%B4%D0%B0%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F-%D1%87%D0%B8-%D0%B7%D0%B0%D0%BC%D1%96%D0%BD%D0%B0-%D0%BA%D0%BE%D0%BC%D0%BF%D0%BE%D0%BD%D0%B5%D0%BD%D1%82%D1%96%D0%B2-%D1%87%D0%B8-%D0%BB%D0%BE%D0%B3%D1%96%D0%BA%D0%B8)
 - [1.1 Поліморфізм](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#11-%D0%BF%D0%BE%D0%BB%D1%96%D0%BC%D0%BE%D1%80%D1%84%D1%96%D0%B7%D0%BC)
 - [1.2 Композиція замість успадкування](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#12-%D0%BA%D0%BE%D0%BC%D0%BF%D0%BE%D0%B7%D0%B8%D1%86%D1%96%D1%8F-%D0%B7%D0%B0%D0%BC%D1%96%D1%81%D1%82%D1%8C-%D1%83%D1%81%D0%BF%D0%B0%D0%B4%D0%BA%D1%83%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F)

[2. Комунікація між компонентами чи системами](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#2--%D0%BA%D0%BE%D0%BC%D1%83%D0%BD%D1%96%D0%BA%D0%B0%D1%86%D1%96%D1%8F-%D0%BC%D1%96%D0%B6-%D0%BA%D0%BE%D0%BC%D0%BF%D0%BE%D0%BD%D0%B5%D0%BD%D1%82%D0%B0%D0%BC%D0%B8-%D1%87%D0%B8-%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0%D0%BC%D0%B8)
 - [2.1. GameHub](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#21-gamehub)
 - [2.2. Game Events](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#22-game-events)

[3. Простий рефакторинг](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#3-%D0%BF%D1%80%D0%BE%D1%81%D1%82%D0%B8%D0%B9-%D1%80%D0%B5%D1%84%D0%B0%D0%BA%D1%82%D0%BE%D1%80%D0%B8%D0%BD%D0%B3)
 - [3.1. Уникайте вкладення префабів](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#31-%D1%83%D0%BD%D0%B8%D0%BA%D0%B0%D0%B9%D1%82%D0%B5-%D0%B2%D0%BA%D0%BB%D0%B0%D0%B4%D0%B5%D0%BD%D0%BD%D1%8F-%D0%BF%D1%80%D0%B5%D1%84%D0%B0%D0%B1%D1%96%D0%B2)
 - [3.2. Використовуйте namespace](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#32-%D0%B2%D0%B8%D0%BA%D0%BE%D1%80%D0%B8%D1%81%D1%82%D0%BE%D0%B2%D1%83%D0%B9%D1%82%D0%B5-namespace)
 - [3.3. GameStorageSystem з PlayerPrefs](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#33-gamestoragesystem-%D0%B7-playerprefs)
 - [3.4. Utils: Cтатичні класи та розширення](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#34-utils-c%D1%82%D0%B0%D1%82%D0%B8%D1%87%D0%BD%D1%96-%D0%BA%D0%BB%D0%B0%D1%81%D0%B8-%D1%82%D0%B0-%D1%80%D0%BE%D0%B7%D1%88%D0%B8%D1%80%D0%B5%D0%BD%D0%BD%D1%8F)

[4. Виловлювання багів](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#4-%D0%B2%D0%B8%D0%BB%D0%BE%D0%B2%D0%BB%D1%8E%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F-%D0%B1%D0%B0%D0%B3%D1%96%D0%B2)
 - [4.1. ContextMenu](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#41-contextmenu)
 - [4.2. Gizmos](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#42-gizmos)
 - [4.3. OnGUI](https://github.com/Shchack/BestPracticesJamGame/tree/main?tab=readme-ov-file#43-ongui)

---
## 1. Додавання чи заміна компонентів чи логіки

### 1.1. Поліморфізм

> Polymorphism. [Поліморфізм](https://uk.wikipedia.org/wiki/%D0%9F%D0%BE%D0%BB%D1%96%D0%BC%D0%BE%D1%80%D1%84%D1%96%D0%B7%D0%BC_(%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D1%83%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F))

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

Структура в UnityEditor виглядає ось так:
![Interaction Demo UnityEditor Hierarchy](https://www.dropbox.com/scl/fi/ozqp3xon2pr4l1zcec6ed/interaction_demo_hierarchy.png?rlkey=hgcp1d996l65ngln4eoq9jk97&raw=1)
 
Завдяки цьому простенькому трюку ми тепер можемо:
- Якщо захочемо підняти книжку, то потрібно просто замінити компонент *Readable* на *Pickable*
- Додати новий предмет для взаємодії - просто обраємо поведінку з нашого набору реалізацій *IInteractable*.
- Спробувати іншу логіку підбирання предмета без втрати попередньої. Просто робимо нову реалізацію, наприклад *PickableWithEffect*

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

### 1.2. Композиція замість успадкування

> Composition over Inheritance. [Композиція в програмуванні](https://foxminded.ua/kompozytsiia-v-prohramuvanni/)

Насправді ця тема глибока і в ній важливо розібратись. В неті можна знайти купу інформації про це. Я ж спробую в кількох словах пояснити що це таке і чому це важливо, особливо в Unity. І композиція, і успадкування дозволяють виокристовувати одну і ту ж логіку в різних об'єктах, але вони принципово відрізняються. Успадкування дозволяє нам створювати похідні об'єкти з існуючих і тому використовувати поведінку цих "батьківських" об'єктів. Наприклад, якщо в нас є об'єкт Їжа (Food), і вона має властивості Колір (Color), Смак (Taste), Запах (Smell), то ми можемо на основі об'єкту Їжа створити тепер ЗіспсованаЇжа (SpoiledFood), яка теж буде мати всі ці властивості Колір, Смак, Запах, але додатково вона ще буде отруювати персонажа при вживанні.

    public class FoodEntity : MonoBehaviour
    {
        [SerializeField] protected string _taste = "Sweet";
        [SerializeField] protected string _smell = "Good";
        [SerializeField] protected string _color = "Green";

        public virtual void Use(PlayerController player)
        {
            Debug.Log($"Tastes {_taste}. Smells {_smell}. Color {_color}");
        }
    }

    public class SpoiledFoodEntity : FoodEntity
    {
        [SerializeField] private string _negativeEffect = "Poisoned";

        public override void Use((PlayerController player)
        {
            Debug.Log($"Spoiled food. Negative effect: {_negativeEffect}");
        }
    }

Але такий підхід не дуже ефективний, оскільки якщо ми захочемо додати, наприклад, дуже корисну їжу з позитивним ефектом чи їжу, яка має і позитивний, і негативний ефект, то нам треба буде створювати нові об'єкти і наше успадкування поламається.

А якщо ми використаємо композицію тут? Композиція дозволяє нам ніби збирати об'єкти з частин, як конструктор. До речі, це дуже добре лягає на архітектуру Unity з її компонентами та сутностями ([ECS - Entity Component System)](https://uk.wikipedia.org/wiki/Entity_Component_System)). В результаті ми отримамо таке:

    public class FoodCompositionEntity : MonoBehaviour
    {
        [SerializeField] private string _name = "Food";
        [SerializeField] private string _taste = "Sweet";
        [SerializeField] private string _smell = "Good";
        [SerializeField] private string _color = "Green";

        [SerializeField] private FoodEffectComponent[] _effects;

        public void Use()
        {
            Debug.Log($"{_name}. Tastes {_taste}. Smells {_smell}. Color {_color}. Has effects:");

            foreach (var effect in _effects)
            {
                Debug.Log($"{effect.Name}. Strength: {effect.Strength}");
            }
        }

        [ContextMenu(nameof(DebugUse))]
        private void DebugUse()
        {
            Use();
        }
    }

    [Serializable]
    public class FoodEffectComponent
    {
        public string Name;
        public int Strength;
    }

Тепер ми можемо в Unity Editor "збирати" їжу з будь-яким набором властивостей і не додавати більше жодного коду.

---
## 2.  Комунікація між компонентами чи системами

### 2.1 GameHub

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

Особисто я звик мати лише один *Singleton* в проєкті з кількома компонентами, щоб не доводилось думати, які ж я там назви попридумував для систем, а також, щоб будь-яку з цих систем можна було легко вивести з категорії одинаків. Для цього я використовую назву **GameHub** (придумав собі її, бо вона відносно коротка, хоча може і ще хтось так її називає). Тепер, коли мені треба звернутись до якоїсь системи я просто пишу GameHub.One.[назва системи]. Покажу приклад реалізації та використання:

    public class GameHub : Singleton<GameHub>
    {
        public GameEventSystem Events { get; private set; }
        public GameStorageSystem Storage { get; private set; }
        public IAudioSystem Audio { get; private set; }
    
        public bool IsInitialized { get; private set; }
    
        public override void Init()
        {
            Events = new GameEventSystem();
            Storage = new GameStorageSystem ();
    
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
	
	------------------------------------------------------------------------------
    
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
### 2.2. Game Events

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
	
	--------------------------------------------------------------------------------
    
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
    
	---------------------------------------------------------------------------------
	
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
## 3. Простий рефакторинг

### 3.1. Уникайте вкладення префабів

Префаби - дуже корисний інструмент конфігурації сцени та перевикористання логіки чи сутностей (*entities*), та, все ж, він має свої мінуси. Зручне та якісне налаштування префабів потребує часу, особливо в процесі активної розробки (а гейм джем якраз час дуже активної розробки). Тому, потрібно бути обережним, щоб не створити складні префаби, в яких вкладені інші префаби, оскільки швидше за все ви дуже часто модифікуватимете саме об'єкти на сцені і в якийсь момент забудете додати ці зміни до префабу. Хоча, якщо ж у вас вже є підхід до використання префабів і вироблена звичка тримати префаби в актуальному стані, то, мабуть, великих проблем з префабами у вас не виникне. Титоріалів та статей про роботу з префабами вже є дуже багато, наприклад [How to use Prefabs in Unity - Game Dev Beginner](https://gamedevbeginner.com/how-to-use-prefabs-in-unity/)
![Prefabs](https://www.dropbox.com/scl/fi/7l5ozk79xjzx1la65klqs/prefabs.png?rlkey=j22abd5es5tprcwamcztz0lxg&raw=1)

---
### 3.2. Використовуйте namespace

[Namespaces](https://docs.unity3d.com/Manual/Namespaces.html) - це спосіб уникати конфліктів між скриптами з однією назвою. Це особливо важливо, якщо ви використовуєте сторонні асети з кодом. Може здатись, що майже неможливо, щоб ви придумали таку ж назву як хтось інший, але це трапляється дуже часто, бо, повірте, класів з назвами GameManager, CharacterController, PlayerMovement існує дуже багато. Тому простий спосіб уникати таких конфліктів і не мучитись з унікальними назвами - це обгортати всі ваші класи в namespace. Також, бажано мати окремий namespace для Editor-скриптів. Залишається ще питання: "А як назвати цей namespace?". Мій підхід до назви namespace такий: корінь має складатись з 2 частин [скорочена назва вашої студії чи вашого ніку].[коротка назва гри]. Якщо у вас назва студії Best Game Studio Ever, а назва гри "Fun Mars Game", то виходить:

    namespace BGSE.FunMarsGame
    
    namespace BGSE.FunMarsGame.Editor

Є ще окреме питання з AssemblyDefinition. [AssemblyDefinitions](https://docs.unity3d.com/Manual/ScriptCompilationAssemblyDefinitionFiles.html) - це ніби збірка коду в одному ящику, який в Unity використовується для організації коду, поширення та оптимізації процесу компіляції. Але на гейм джемі швидкість розробки це все. Тому краще уникати додаткових налаштувань, перекидувань скриптів між цими модулями, налаштування зв'язків між ними. За замовчуванням Unity автоматично пакує всі ваші скрипти в один Assembly-CSharp і для джем гри цього цілком достатньо, але для комерційних середніх і великих проєктів використання AssemblyDefinition - це практично необхідність.

---
### 3.3. GameStorageSystem з PlayerPrefs

Майже всі ігри повинні мати збереження прогресу гравця та стану гри. Підходів до збереження існує безліч, але у нашому випадку час - це ключ. В Unity - найпростішим способом є збереження у [PlayerPrefs](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html). Якщо вам потрібно зберігати прості типи і невеликі об'єми даних, то цього достатньо у більшості випадках (але якщо ідея гри передбачає великі світи і складні типи даних, то все ж варто витратити час на якусь складнішу систему). Розповідати як користуватись PlayerPrefs я тут не буду, бо ці пояснення легко знайти в інтернеті, наприклад тут [How to use Player Prefs in Unity](https://gamedevbeginner.com/how-to-use-player-prefs-in-unity/). 
Але користуватись бездумно PlayerPrefs теж не варто, бо потім при рефакторингу чи зміні системи збереження виловлювати їх по всьому коду буде дуже складно. Тому я завжди використовую якусь обгортку, щоб тримати збереження даних в одному місці. Нам знадобиться клас GameStorageSystem та GameHub описаний вище, оскільки це якраз глобальна система, яка може зберігати глобальний стан гри.

    public class GameStorageSystem
    {
        public event Action<int> OnCoinsChangedEvent;

        private const string COINS_PREF_NAME = "Coins";
        private const int DEFAULT_COINS_VALUE = 0;

        private int _coins;

        public GameStorageSystem()
        {
            _coins = PlayerPrefs.GetInt(COINS_PREF_NAME, DEFAULT_COINS_VALUE);
        }

        public int GetCoins()
        {
            return _coins;
        }

        public void SetCoins(int newCoins)
        {
            _coins = newCoins;
            PlayerPrefs.SetInt(COINS_PREF_NAME, newCoins);
            OnCoinsChangedEvent?.Invoke(_coins);
        }
    }
	
Тут ми не лише змінюємо кількість монет, а й зберігаємо їх, а також повідомляємо про зміни. Тепер нам не треба повторювати цю логіку по всьому коду, а можна просто викликати метод SetCoins.

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private float _moveSpeed = 1f;

        private int _coins;

        private void Start()
        {
            _coins = GameHub.One.Storage.GetCoins();
        }

        public void PickupCoin()
        {
            _coins += 1;
            GameHub.One.Storage.SetCoins(_coins);
        }
        ...
    }
		
---
### 3.4. Utils: Cтатичні класи та розширення

Якщо в нас є метод, який використовується в кількох місцях, але він не залежить від стану об'єкта, то можна цей метод зробити статичним і додати в статичний клас, щоб потім використовувати всюди. Цим способом треба користуватись обережно, бо логіка не так часто є незалежною від об'єкта. Але такі випадки існуюють. Перетворення координат, форматування стрічок, математичні калькуляції - саме для таких випадків можна використати статичні класи. Я люблю називати такі класи Utils. Тут трохи простий та наївний приклад, але я думаю ви зрозумієте ідею

    public static class GameTextFormatUtils
    {
        public static string GetFormattedCoinText(int coins)
        {
            return $"Coins: {coins}";
        }
    }

Інший варіант використання подібного підходу це [Метод-розширення (Extension Method)](https://uk.wikipedia.org/wiki/%D0%9C%D0%B5%D1%82%D0%BE%D0%B4_%D1%80%D0%BE%D0%B7%D1%88%D0%B8%D1%80%D0%B5%D0%BD%D0%BD%D1%8F). Якщо в нас вже є якесь значення певного типу, то ми можемо додати наш власний метод в набір його методів. Це, в деяких випадках, зручніший спосіб використання статичних методів через крапку. Тут теж простий приклад, в якому ми форматуємо дату у зручний для виводу час дня.

	public static class DateTimeExtensions
	{
	    public static string ToDayTimeText(this DateTime dateTime)
	    {
	        return dateTime.ToString("HH:mm");
	    }
	}

А ось як ми це використовуємо

    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsLabel;
        [SerializeField] private TMP_Text _dateLabel;

        ...

        private void Update()
        {
	        // Метод-розширення
            _dateLabel.text = DateTime.Now.ToDayTimeText(); 
        }

        private void SetCoinsLabel(int coins)
        {
	        // Статичний клас
            _coinsLabel.text = GameTextFormatUtils.GetFormattedCoinText(coins);
        }
        
		...
    }

---
## 4. Виловлювання багів

Виловлювання багів ([Debug C# code in Unity](https://docs.unity3d.com/Manual/ManagedCodeDebugging.html)) - важливий процес розробки. Звісно в Unity є класичні способи дебагінгу, такі як покроковий за допомогою breakpoins та звісно ж улюблений для всіх Debug.Log. Але в Unity є набагато наочніші способи дебагу і це важливо оскільки ми маємо справу з аудіо-візуальною програмою - грою.

### 4.1. ContextMenu

Припустимо ми хочемо протестувати різну кількість монет в гравця, але для цього треба ще помучитись, щоб їх зібрати. Ми можемо використати чіт і дати нашому персонажу багато монет, одразу цілу 1000. Зробити це дуже просто через атрибут [ContextMenu](https://docs.unity3d.com/ScriptReference/ContextMenu.html):

    public class PlayerController : MonoBehaviour
    {
	    ...
	    
        [ContextMenu(nameof(Give1000Coins))]
        private void Give1000Coins()
        {
            _coins = 1000;
            GameHub.One.Storage.SetCoins(_coins);
        }
    }

Тепер під час гри ми можемо викликати цей метод з меню в Інспекторі

![Give 1000 Coins](https://www.dropbox.com/scl/fi/itm0f5uni59gb2wcoywwj/context_menu.png?rlkey=8yx6rzc0pvtztjo8nqqw5i7s3&raw=1)

---
### 4.2. Gizmos

[OnDrawGizmos() та OnDrawGizmosSelected()](https://docs.unity3d.com/Manual/GizmosAndHandles.html)  - ці 2 методи дозволяють малювати наші власні елементи у вікні Scene. Різниця між ними у тому, що перший малюється завжди, а другий лише, коли виділити об'єкт в Hierarchy. Використовувати їх дуже просто. Потрібно лише додати цей метод в скрипт MonoBehaviour. В цьому прикладі ми просто малюємо лінію від центру нашого об'єкта в напрямку куди він рухається.

    public class PlayerController : MonoBehaviour
    {
	    ...
	    
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + _moveDirection * 4);
        }
    }

---
### 4.3. OnGUI

Припустимо ми хочемо протестувати респаун гравця після програшу, але для цього треба ще треба чекати, щоб його трохи побили вороги. Замість того, щоб з важким серцем дивитися як нашого аватара б'ють ми можемо звершити його страждання викликом методу Respawn вручну. Для цього треба додати новий метод [OnGUI](https://docs.unity3d.com/Manual/gui-Controls.html) в PlayerController:

    public class PlayerController : MonoBehaviour
    {
        ...

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(0f, 0f, 100f, 20f));
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Respawn"))
            {
                transform.position = Vector3.zero;
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
    }

Тепер під час гри у верхньому лівому куті вікна Game буде кнопка Respawn:

![Respawn](https://www.dropbox.com/scl/fi/v26aaxann7p78fjhcqlsg/respawn_ongui.png?rlkey=i9plorlwc6gvo0upwal2l6y1b&raw=1)

---
## Наостанок

Ще одний важливий момент: "знайте свої інструменти". Дуже часто виникає бажання використати інструмент, який вже зробили до тебе, бо "навіщо вигадувати свій велосипед". Діалогова система, контролер персонажа, фізика управління машиною - є безліч готових асетів з реалізацією якоїсь поведінки. Але, завжди треба зважувати чи дійсно легше буде використати готовий варіант. В будь-якій логіці, яку не ви писали, доведеться розбиратись, а також вона часто міститиме код, який вам не потрібен, але на ньому зав'язані інші компоненти. Тому тут я використовую такі правила:

1) Чи працював я з цим асетом до цього?
2) Чи дійсно мені було легко з ним працювати?
2) Чи потрібен мені весь функціонал асета, чи я можу обійтись написанням кількох компонентів, які мені потрібні?
3) Чи цікаво і корисно мені було б в рамках джему самостійно написати потрібну логіку?
---
Щось з того, що я тут розповів не бажано використовувати в комерційних геймдев проєктах, а щось цілком підійде. Можливо, вам якісь підходи чи код видалися неправильними чи недовершеними. І, мабуть, ви будете мати рацію, але я не мав на меті описати best practices, як їх подають у підручниках, а швидше запропонувати те, що, на мою думку, працює коли треба швидко зробити гру на гейм-джемі чи запилити прототипчик.

Звісно, якщо у вас є пропозиції чи зауваження по цій темі, я б зрадістю з вами їх обговорив, наприклад в discord-спільноті [Ігровари](https://discord.com/invite/igrovari-747455818097623040).

І ще таке - якщо б я міг обрати підхід в розробці, який мені найбільше подобається (але якого я далеко не завжди дотримуюсь) - це [KISS](https://uk.wikipedia.org/wiki/%D0%9F%D1%80%D0%B8%D0%BD%D1%86%D0%B8%D0%BF_%C2%ABKISS%C2%BB) "пиши простий та стислий код" і ускладнюй систему лише коли це потрібно, бо інакше можна застрягнути в постійному переписуванні/покращенні і забути про головне:

> "Створити цікаву гру можна, якщо тобі цікаво ЇЇ розробляти".
