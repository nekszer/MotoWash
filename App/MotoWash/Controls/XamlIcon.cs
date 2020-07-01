﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MotoWash.Controls
{
    public class Icon : ContentView
    {

        #region BindableProperty Glyph
        /// <summary>
        /// Glyph
        /// </summary>
        public static readonly BindableProperty GlyphProperty = BindableProperty.Create(nameof(Glyph), typeof(Glyph), typeof(Icon), default(string), BindingMode.OneWay);

        /// <summary>
        /// Glyph
        /// </summary>
        public Glyph Glyph
        {
            get
            {
                return (Glyph)GetValue(GlyphProperty);
            }

            set
            {
                SetValue(GlyphProperty, value);
            }
        }
        #endregion

        #region BindableProperty Color
        /// <summary>
        /// Color
        /// </summary>
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(Icon), default(Color), BindingMode.OneWay);

        /// <summary>
        /// Color
        /// </summary>
        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }

            set
            {
                SetValue(ColorProperty, value);
            }
        }
        #endregion

        #region BindableProperty Size
        /// <summary>
        /// Size
        /// </summary>
        public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(double), typeof(Icon), default(double), BindingMode.OneWay);

        /// <summary>
        /// Size
        /// </summary>
        public double Size
        {
            get
            {
                return (double)GetValue(SizeProperty);
            }

            set
            {
                SetValue(SizeProperty, value);
            }
        }
        #endregion

        #region BindableProperty Command
        /// <summary>
        /// Command
        /// </summary>
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(Icon), default(ICommand), BindingMode.OneWay);

        /// <summary>
        /// Command
        /// </summary>
        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }

            set
            {
                SetValue(CommandProperty, value);
            }
        }
        #endregion

        private FontImageSource ImageSource { get; }

        private Image Image { get; }

        public Icon()
        {
            var fontawesome = (Application.Current.Resources["FontAwesome"] as OnPlatform<string>);
            var platform = fontawesome.Platforms.FirstOrDefault(p => p.Platform.Any(rp => rp == Device.RuntimePlatform));
            ImageSource = new FontImageSource
            {
                FontFamily = platform?.Value?.ToString() ?? ""
            };
            Image = new Image();
            Content = Image;
            BindableProperties = new List<BindablePropertyChanged>
            {
                new BindablePropertyChanged(GlyphProperty, () =>
                {
                    ImageSource.Glyph = typeof(FontAwesome).GetField(Glyph.ToString()).GetValue(null).ToString();
                    Image.Source = ImageSource;
                }),
                new BindablePropertyChanged(SizeProperty, () =>
                {
                    ImageSource.Size = Size;
                }),
                new BindablePropertyChanged(ColorProperty, () =>
                {
                    ImageSource.Color = Color;
                }),
                new BindablePropertyChanged(CommandProperty, () =>
                {
                    Image.GestureRecognizers.Clear();
                    Image.GestureRecognizers.Add(new TapGestureRecognizer
                    {
                        Command = Command
                    });
                })
            };
        }


        #region Bindable Property Changed
        public List<BindablePropertyChanged> BindableProperties { get; set; }
        protected override void OnPropertyChanged(string propertyname = null)
        {
            base.OnPropertyChanged(propertyname);
            if (BindableProperties == null) return;
            BindableProperties.FirstOrDefault(b => b.PropertyChanged(propertyname));
        }

        public class BindablePropertyChanged
        {
            protected string PropetyName
            {
                get
                {
                    return SourceProperty?.PropertyName;
                }
            }
            protected BindableProperty SourceProperty;
            protected Action Action { get; set; }

            public BindablePropertyChanged(BindableProperty sourceproperty, Action action)
            {
                SourceProperty = sourceproperty;
                Action = action;
            }

            public bool PropertyChanged(string propertyname)
            {
                if (SourceProperty.PropertyName != propertyname) return false;
                Action?.Invoke();
                return true;
            }
        }
        #endregion
    }

    public enum Glyph
    {
        GlassMartini,
        Music,
        Search,
        Heart,
        Star,
        User,
        Film,
        ThLarge,
        Th,
        ThList,
        Check,
        Times,
        SearchPlus,
        SearchMinus,
        PowerOff,
        Signal,
        Cog,
        Home,
        Clock,
        Road,
        Download,
        Inbox,
        Redo,
        Sync,
        ListAlt,
        Lock,
        Flag,
        Headphones,
        VolumeOff,
        VolumeDown,
        VolumeUp,
        Qrcode,
        Barcode,
        Tag,
        Tags,
        Book,
        Bookmark,
        Print,
        Camera,
        Font,
        Bold,
        Italic,
        TextHeight,
        TextWidth,
        AlignLeft,
        AlignCenter,
        AlignRight,
        AlignJustify,
        List,
        Outdent,
        Indent,
        Video,
        Image,
        MapMarker,
        Adjust,
        Tint,
        Edit,
        StepBackward,
        FastBackward,
        Backward,
        Play,
        Pause,
        Stop,
        Forward,
        FastForward,
        StepForward,
        Eject,
        ChevronLeft,
        ChevronRight,
        PlusCircle,
        MinusCircle,
        TimesCircle,
        CheckCircle,
        QuestionCircle,
        InfoCircle,
        Crosshairs,
        Ban,
        ArrowLeft,
        ArrowRight,
        ArrowUp,
        ArrowDown,
        Share,
        Expand,
        Compress,
        Plus,
        Minus,
        Asterisk,
        ExclamationCircle,
        Gift,
        Leaf,
        Fire,
        Eye,
        EyeSlash,
        ExclamationTriangle,
        Plane,
        CalendarAlt,
        Random,
        Comment,
        Magnet,
        ChevronUp,
        ChevronDown,
        Retweet,
        ShoppingCart,
        Folder,
        FolderOpen,
        ChartBar,
        CameraRetro,
        Key,
        Cogs,
        Comments,
        StarHalf,
        Thumbtack,
        Trophy,
        Upload,
        Lemon,
        Phone,
        PhoneSquare,
        Unlock,
        CreditCard,
        Rss,
        Hdd,
        Bullhorn,
        Certificate,
        HandPointRight,
        HandPointLeft,
        HandPointUp,
        HandPointDown,
        ArrowCircleLeft,
        ArrowCircleRight,
        ArrowCircleUp,
        ArrowCircleDown,
        Globe,
        Wrench,
        Tasks,
        Filter,
        Briefcase,
        ArrowsAlt,
        Users,
        Link,
        Cloud,
        Flask,
        Cut,
        Copy,
        Paperclip,
        Save,
        Square,
        Bars,
        ListUl,
        ListOl,
        Strikethrough,
        Underline,
        Table,
        Magic,
        Truck,
        MoneyBill,
        CaretDown,
        CaretUp,
        CaretLeft,
        CaretRight,
        Columns,
        Sort,
        SortDown,
        SortUp,
        Envelope,
        Undo,
        Gavel,
        Bolt,
        Sitemap,
        Umbrella,
        Paste,
        Lightbulb,
        UserMd,
        Stethoscope,
        Suitcase,
        Bell,
        Coffee,
        Hospital,
        Ambulance,
        Medkit,
        FighterJet,
        Beer,
        HSquare,
        PlusSquare,
        AngleDoubleLeft,
        AngleDoubleRight,
        AngleDoubleUp,
        AngleDoubleDown,
        AngleLeft,
        AngleRight,
        AngleUp,
        AngleDown,
        Desktop,
        Laptop,
        Tablet,
        Mobile,
        QuoteLeft,
        QuoteRight,
        Spinner,
        Circle,
        Smile,
        Frown,
        Meh,
        Gamepad,
        Keyboard,
        FlagCheckered,
        Terminal,
        Code,
        ReplyAll,
        LocationArrow,
        Crop,
        CodeBranch,
        Unlink,
        Question,
        Info,
        Exclamation,
        Superscript,
        Subscript,
        Eraser,
        PuzzlePiece,
        Microphone,
        MicrophoneSlash,
        Calendar,
        FireExtinguisher,
        Rocket,
        ChevronCircleLeft,
        ChevronCircleRight,
        ChevronCircleUp,
        ChevronCircleDown,
        Anchor,
        UnlockAlt,
        Bullseye,
        EllipsisH,
        EllipsisV,
        RssSquare,
        PlayCircle,
        MinusSquare,
        CheckSquare,
        PenSquare,
        ShareSquare,
        Compass,
        CaretSquareDown,
        CaretSquareUp,
        CaretSquareRight,
        EuroSign,
        PoundSign,
        DollarSign,
        RupeeSign,
        YenSign,
        RubleSign,
        WonSign,
        File,
        FileAlt,
        SortAlphaDown,
        SortAlphaUp,
        SortAmountDown,
        SortAmountUp,
        SortNumericDown,
        SortNumericUp,
        ThumbsUp,
        ThumbsDown,
        Female,
        Male,
        Sun,
        Moon,
        Archive,
        Bug,
        CaretSquareLeft,
        DotCircle,
        Wheelchair,
        LiraSign,
        SpaceShuttle,
        EnvelopeSquare,
        University,
        GraduationCap,
        Language,
        Fax,
        Building,
        Child,
        Paw,
        Cube,
        Cubes,
        Recycle,
        Car,
        Taxi,
        Tree,
        Database,
        FilePdf,
        FileWord,
        FileExcel,
        FilePowerpoint,
        FileImage,
        FileArchive,
        FileAudio,
        FileVideo,
        FileCode,
        LifeRing,
        CircleNotch,
        PaperPlane,
        History,
        Heading,
        Paragraph,
        SlidersH,
        ShareAlt,
        ShareAltSquare,
        Bomb,
        Futbol,
        Tty,
        Binoculars,
        Plug,
        Newspaper,
        Wifi,
        Calculator,
        BellSlash,
        Trash,
        Copyright,
        At,
        EyeDropper,
        PaintBrush,
        BirthdayCake,
        ChartArea,
        ChartPie,
        ChartLine,
        ToggleOff,
        ToggleOn,
        Bicycle,
        Bus,
        ClosedCaptioning,
        ShekelSign,
        CartPlus,
        CartArrowDown,
        Ship,
        UserSecret,
        Motorcycle,
        StreetView,
        Heartbeat,
        Venus,
        Mars,
        Mercury,
        Transgender,
        TransgenderAlt,
        VenusDouble,
        MarsDouble,
        VenusMars,
        MarsStroke,
        MarsStrokeV,
        MarsStrokeH,
        Neuter,
        Genderless,
        Server,
        UserPlus,
        UserTimes,
        Bed,
        Train,
        Subway,
        BatteryFull,
        BatteryThreeQuarters,
        BatteryHalf,
        BatteryQuarter,
        BatteryEmpty,
        MousePointer,
        ICursor,
        ObjectGroup,
        ObjectUngroup,
        StickyNote,
        Clone,
        BalanceScale,
        HourglassStart,
        HourglassHalf,
        HourglassEnd,
        Hourglass,
        HandRock,
        HandPaper,
        HandScissors,
        HandLizard,
        HandSpock,
        HandPointer,
        HandPeace,
        Trademark,
        Registered,
        Tv,
        CalendarPlus,
        CalendarMinus,
        CalendarTimes,
        CalendarCheck,
        Industry,
        MapPin,
        MapSigns,
        Map,
        CommentAlt,
        PauseCircle,
        StopCircle,
        ShoppingBag,
        ShoppingBasket,
        Hashtag,
        Percent,
        UniversalAccess,
        Blind,
        AudioDescription,
        PhoneVolume,
        Braille,
        AssistiveListeningSystems,
        AmericanSignLanguageInterpreting,
        Deaf,
        SignLanguage,
        LowVision,
        Handshake,
        EnvelopeOpen,
        AddressBook,
        AddressCard,
        UserCircle,
        IdBadge,
        IdCard,
        ThermometerFull,
        ThermometerThreeQuarters,
        ThermometerHalf,
        ThermometerQuarter,
        ThermometerEmpty,
        Shower,
        Bath,
        Podcast,
        WindowMaximize,
        WindowMinimize,
        WindowRestore,
        Microchip,
        Snowflake,
        UtensilSpoon,
        Utensils,
        UndoAlt,
        TrashAlt,
        SyncAlt,
        Stopwatch,
        SignOutAlt,
        SignInAlt,
        RedoAlt,
        Poo,
        Images,
        PencilAlt,
        Pen,
        PenAlt,
        LongArrowAltDown,
        LongArrowAltLeft,
        LongArrowAltRight,
        LongArrowAltUp,
        ExpandArrowsAlt,
        Clipboard,
        ArrowsAltH,
        ArrowsAltV,
        ArrowAltCircleDown,
        ArrowAltCircleLeft,
        ArrowAltCircleRight,
        ArrowAltCircleUp,
        ExternalLinkAlt,
        ExternalLinkSquareAlt,
        ExchangeAlt,
        CloudDownloadAlt,
        CloudUploadAlt,
        Gem,
        LevelDownAlt,
        LevelUpAlt,
        LockOpen,
        MapMarkerAlt,
        MicrophoneAlt,
        MobileAlt,
        MoneyBillAlt,
        PhoneSlash,
        Portrait,
        Reply,
        ShieldAlt,
        TabletAlt,
        TachometerAlt,
        TicketAlt,
        UserAlt,
        WindowClose,
        CompressAlt,
        ExpandAlt,
        BaseballBall,
        BasketballBall,
        BowlingBall,
        Chess,
        ChessBishop,
        ChessBoard,
        ChessKing,
        ChessKnight,
        ChessPawn,
        ChessQueen,
        ChessRook,
        Dumbbell,
        FootballBall,
        GolfBall,
        HockeyPuck,
        Quidditch,
        SquareFull,
        TableTennis,
        VolleyballBall,
        Allergies,
        BandAid,
        Box,
        Boxes,
        BriefcaseMedical,
        Burn,
        Capsules,
        ClipboardCheck,
        ClipboardList,
        Diagnoses,
        Dna,
        Dolly,
        DollyFlatbed,
        FileMedical,
        FileMedicalAlt,
        FirstAid,
        HospitalAlt,
        HospitalSymbol,
        IdCardAlt,
        NotesMedical,
        Pallet,
        Pills,
        PrescriptionBottle,
        PrescriptionBottleAlt,
        Procedures,
        ShippingFast,
        Smoking,
        Syringe,
        Tablets,
        Thermometer,
        Vial,
        Vials,
        Warehouse,
        Weight,
        XRay,
        BoxOpen,
        CommentDots,
        CommentSlash,
        Couch,
        Donate,
        Dove,
        HandHolding,
        HandHoldingHeart,
        HandHoldingUsd,
        Hands,
        HandsHelping,
        ParachuteBox,
        PeopleCarry,
        PiggyBank,
        Ribbon,
        Route,
        Seedling,
        Sign,
        SmileWink,
        Tape,
        TruckLoading,
        TruckMoving,
        VideoSlash,
        WineGlass,
        UserAltSlash,
        UserAstronaut,
        UserCheck,
        UserClock,
        UserCog,
        UserEdit,
        UserFriends,
        UserGraduate,
        UserLock,
        UserMinus,
        UserNinja,
        UserShield,
        UserSlash,
        UserTag,
        UserTie,
        UsersCog,
        BalanceScaleLeft,
        BalanceScaleRight,
        Blender,
        BookOpen,
        BroadcastTower,
        Broom,
        Chalkboard,
        ChalkboardTeacher,
        Church,
        Coins,
        CompactDisc,
        Crow,
        Crown,
        Dice,
        DiceFive,
        DiceFour,
        DiceOne,
        DiceSix,
        DiceThree,
        DiceTwo,
        Divide,
        DoorClosed,
        DoorOpen,
        Equals,
        Feather,
        Frog,
        GasPump,
        Glasses,
        GreaterThan,
        GreaterThanEqual,
        Helicopter,
        Infinity,
        KiwiBird,
        LessThan,
        LessThanEqual,
        Memory,
        MicrophoneAltSlash,
        MoneyBillWave,
        MoneyBillWaveAlt,
        MoneyCheck,
        MoneyCheckAlt,
        NotEqual,
        Palette,
        Parking,
        Percentage,
        ProjectDiagram,
        Receipt,
        Robot,
        Ruler,
        RulerCombined,
        RulerHorizontal,
        RulerVertical,
        School,
        Screwdriver,
        ShoePrints,
        Skull,
        SmokingBan,
        Store,
        StoreAlt,
        Stream,
        Stroopwafel,
        Toolbox,
        Tshirt,
        Walking,
        Wallet,
        Angry,
        Archway,
        Atlas,
        Award,
        Backspace,
        BezierCurve,
        Bong,
        Brush,
        BusAlt,
        Cannabis,
        CheckDouble,
        Cocktail,
        ConciergeBell,
        Cookie,
        CookieBite,
        CropAlt,
        DigitalTachograph,
        Dizzy,
        DraftingCompass,
        Drum,
        DrumSteelpan,
        FeatherAlt,
        FileContract,
        FileDownload,
        FileExport,
        FileImport,
        FileInvoice,
        FileInvoiceDollar,
        FilePrescription,
        FileSignature,
        FileUpload,
        Fill,
        FillDrip,
        Fingerprint,
        Fish,
        Flushed,
        FrownOpen,
        GlassMartiniAlt,
        GlobeAfrica,
        GlobeAmericas,
        GlobeAsia,
        Grimace,
        Grin,
        GrinAlt,
        GrinBeam,
        GrinBeamSweat,
        GrinHearts,
        GrinSquint,
        GrinSquintTears,
        GrinStars,
        GrinTears,
        GrinTongue,
        GrinTongueSquint,
        GrinTongueWink,
        GrinWink,
        GripHorizontal,
        GripVertical,
        HeadphonesAlt,
        Headset,
        Highlighter,
        HotTub,
        Hotel,
        Joint,
        Kiss,
        KissBeam,
        KissWinkHeart,
        Laugh,
        LaughBeam,
        LaughSquint,
        LaughWink,
        LuggageCart,
        MapMarked,
        MapMarkedAlt,
        Marker,
        Medal,
        MehBlank,
        MehRollingEyes,
        Monument,
        MortarPestle,
        PaintRoller,
        Passport,
        PenFancy,
        PenNib,
        PencilRuler,
        PlaneArrival,
        PlaneDeparture,
        Prescription,
        SadCry,
        SadTear,
        ShuttleVan,
        Signature,
        SmileBeam,
        SolarPanel,
        Spa,
        Splotch,
        SprayCan,
        Stamp,
        StarHalfAlt,
        SuitcaseRolling,
        Surprise,
        Swatchbook,
        Swimmer,
        SwimmingPool,
        TintSlash,
        Tired,
        Tooth,
        UmbrellaBeach,
        VectorSquare,
        WeightHanging,
        WineGlassAlt,
        AirFreshener,
        AppleAlt,
        Atom,
        Bone,
        BookReader,
        Brain,
        CarAlt,
        CarBattery,
        CarCrash,
        CarSide,
        ChargingStation,
        Directions,
        DrawPolygon,
        LaptopCode,
        LayerGroup,
        Microscope,
        OilCan,
        Poop,
        Shapes,
        StarOfLife,
        Teeth,
        TeethOpen,
        TheaterMasks,
        TrafficLight,
        TruckMonster,
        TruckPickup,
        Ad,
        Ankh,
        Bible,
        BusinessTime,
        City,
        CommentDollar,
        CommentsDollar,
        Cross,
        Dharmachakra,
        EnvelopeOpenText,
        FolderMinus,
        FolderPlus,
        FunnelDollar,
        Gopuram,
        Hamsa,
        Bahai,
        Jedi,
        JournalWhills,
        Kaaba,
        Khanda,
        Landmark,
        MailBulk,
        Menorah,
        Mosque,
        Om,
        Pastafarianism,
        Peace,
        PlaceOfWorship,
        Poll,
        PollH,
        Pray,
        PrayingHands,
        Quran,
        SearchDollar,
        SearchLocation,
        Socks,
        SquareRootAlt,
        StarAndCrescent,
        StarOfDavid,
        Synagogue,
        Torah,
        ToriiGate,
        Vihara,
        VolumeMute,
        YinYang,
        BlenderPhone,
        BookDead,
        Campground,
        Cat,
        Chair,
        CloudMoon,
        CloudSun,
        DiceD20,
        DiceD6,
        Dog,
        Dragon,
        DrumstickBite,
        Dungeon,
        FileCsv,
        FistRaised,
        Ghost,
        Hammer,
        Hanukiah,
        HatWizard,
        Hiking,
        Hippo,
        Horse,
        HouseDamage,
        Hryvnia,
        Mask,
        Mountain,
        NetworkWired,
        Otter,
        Ring,
        Running,
        Scroll,
        SkullCrossbones,
        Slash,
        Spider,
        ToiletPaper,
        Tractor,
        UserInjured,
        VrCardboard,
        Wind,
        WineBottle,
        CloudMeatball,
        CloudMoonRain,
        CloudRain,
        CloudShowersHeavy,
        CloudSunRain,
        Democrat,
        FlagUsa,
        Meteor,
        PersonBooth,
        PooStorm,
        Rainbow,
        Republican,
        Smog,
        TemperatureHigh,
        TemperatureLow,
        VoteYea,
        Water,
        Baby,
        BabyCarriage,
        Biohazard,
        Blog,
        CalendarDay,
        CalendarWeek,
        CandyCane,
        Carrot,
        CashRegister,
        CompressArrowsAlt,
        Dumpster,
        DumpsterFire,
        Ethernet,
        Gifts,
        GlassCheers,
        GlassWhiskey,
        GlobeEurope,
        GripLines,
        GripLinesVertical,
        Guitar,
        HeartBroken,
        HollyBerry,
        HorseHead,
        Icicles,
        Igloo,
        Mitten,
        MugHot,
        Radiation,
        RadiationAlt,
        Restroom,
        Satellite,
        SatelliteDish,
        SdCard,
        SimCard,
        Skating,
        Skiing,
        SkiingNordic,
        Sleigh,
        Sms,
        Snowboarding,
        Snowman,
        Snowplow,
        Tenge,
        Toilet,
        Tools,
        Tram,
        FireAlt,
        Bacon,
        BookMedical,
        BreadSlice,
        Cheese,
        ClinicMedical,
        CommentMedical,
        Crutch,
        Egg,
        Hamburger,
        HandMiddleFinger,
        HardHat,
        Hotdog,
        IceCream,
        LaptopMedical,
        Pager,
        PepperHot,
        PizzaSlice,
        TrashRestore,
        TrashRestoreAlt,
        UserNurse,
        WaveSquare,
        Biking,
        BorderAll,
        BorderNone,
        BorderStyle,
        Fan,
        Icons,
        PhoneAlt,
        PhoneSquareAlt,
        PhotoVideo,
        RemoveFormat,
        SortAlphaDownAlt,
        SortAlphaUpAlt,
        SortAmountDownAlt,
        SortAmountUpAlt,
        SortNumericDownAlt,
        SortNumericUpAlt,
        SpellCheck,
        Voicemail,
        HatCowboy,
        HatCowboySide,
        Mouse,
        RecordVinyl,
        Caravan,
        Trailer
    }

    public static class FontAwesome
    {
        public const string GlassMartini = "\uf000";
        public const string Music = "\uf001";
        public const string Search = "\uf002";
        public const string Heart = "\uf004";
        public const string Star = "\uf005";
        public const string User = "\uf007";
        public const string Film = "\uf008";
        public const string ThLarge = "\uf009";
        public const string Th = "\uf00a";
        public const string ThList = "\uf00b";
        public const string Check = "\uf00c";
        public const string Times = "\uf00d";
        public const string SearchPlus = "\uf00e";
        public const string SearchMinus = "\uf010";
        public const string PowerOff = "\uf011";
        public const string Signal = "\uf012";
        public const string Cog = "\uf013";
        public const string Home = "\uf015";
        public const string Clock = "\uf017";
        public const string Road = "\uf018";
        public const string Download = "\uf019";
        public const string Inbox = "\uf01c";
        public const string Redo = "\uf01e";
        public const string Sync = "\uf021";
        public const string ListAlt = "\uf022";
        public const string Lock = "\uf023";
        public const string Flag = "\uf024";
        public const string Headphones = "\uf025";
        public const string VolumeOff = "\uf026";
        public const string VolumeDown = "\uf027";
        public const string VolumeUp = "\uf028";
        public const string Qrcode = "\uf029";
        public const string Barcode = "\uf02a";
        public const string Tag = "\uf02b";
        public const string Tags = "\uf02c";
        public const string Book = "\uf02d";
        public const string Bookmark = "\uf02e";
        public const string Print = "\uf02f";
        public const string Camera = "\uf030";
        public const string Font = "\uf031";
        public const string Bold = "\uf032";
        public const string Italic = "\uf033";
        public const string TextHeight = "\uf034";
        public const string TextWidth = "\uf035";
        public const string AlignLeft = "\uf036";
        public const string AlignCenter = "\uf037";
        public const string AlignRight = "\uf038";
        public const string AlignJustify = "\uf039";
        public const string List = "\uf03a";
        public const string Outdent = "\uf03b";
        public const string Indent = "\uf03c";
        public const string Video = "\uf03d";
        public const string Image = "\uf03e";
        public const string MapMarker = "\uf041";
        public const string Adjust = "\uf042";
        public const string Tint = "\uf043";
        public const string Edit = "\uf044";
        public const string StepBackward = "\uf048";
        public const string FastBackward = "\uf049";
        public const string Backward = "\uf04a";
        public const string Play = "\uf04b";
        public const string Pause = "\uf04c";
        public const string Stop = "\uf04d";
        public const string Forward = "\uf04e";
        public const string FastForward = "\uf050";
        public const string StepForward = "\uf051";
        public const string Eject = "\uf052";
        public const string ChevronLeft = "\uf053";
        public const string ChevronRight = "\uf054";
        public const string PlusCircle = "\uf055";
        public const string MinusCircle = "\uf056";
        public const string TimesCircle = "\uf057";
        public const string CheckCircle = "\uf058";
        public const string QuestionCircle = "\uf059";
        public const string InfoCircle = "\uf05a";
        public const string Crosshairs = "\uf05b";
        public const string Ban = "\uf05e";
        public const string ArrowLeft = "\uf060";
        public const string ArrowRight = "\uf061";
        public const string ArrowUp = "\uf062";
        public const string ArrowDown = "\uf063";
        public const string Share = "\uf064";
        public const string Expand = "\uf065";
        public const string Compress = "\uf066";
        public const string Plus = "\uf067";
        public const string Minus = "\uf068";
        public const string Asterisk = "\uf069";
        public const string ExclamationCircle = "\uf06a";
        public const string Gift = "\uf06b";
        public const string Leaf = "\uf06c";
        public const string Fire = "\uf06d";
        public const string Eye = "\uf06e";
        public const string EyeSlash = "\uf070";
        public const string ExclamationTriangle = "\uf071";
        public const string Plane = "\uf072";
        public const string CalendarAlt = "\uf073";
        public const string Random = "\uf074";
        public const string Comment = "\uf075";
        public const string Magnet = "\uf076";
        public const string ChevronUp = "\uf077";
        public const string ChevronDown = "\uf078";
        public const string Retweet = "\uf079";
        public const string ShoppingCart = "\uf07a";
        public const string Folder = "\uf07b";
        public const string FolderOpen = "\uf07c";
        public const string ChartBar = "\uf080";
        public const string CameraRetro = "\uf083";
        public const string Key = "\uf084";
        public const string Cogs = "\uf085";
        public const string Comments = "\uf086";
        public const string StarHalf = "\uf089";
        public const string Thumbtack = "\uf08d";
        public const string Trophy = "\uf091";
        public const string Upload = "\uf093";
        public const string Lemon = "\uf094";
        public const string Phone = "\uf095";
        public const string PhoneSquare = "\uf098";
        public const string Unlock = "\uf09c";
        public const string CreditCard = "\uf09d";
        public const string Rss = "\uf09e";
        public const string Hdd = "\uf0a0";
        public const string Bullhorn = "\uf0a1";
        public const string Certificate = "\uf0a3";
        public const string HandPointRight = "\uf0a4";
        public const string HandPointLeft = "\uf0a5";
        public const string HandPointUp = "\uf0a6";
        public const string HandPointDown = "\uf0a7";
        public const string ArrowCircleLeft = "\uf0a8";
        public const string ArrowCircleRight = "\uf0a9";
        public const string ArrowCircleUp = "\uf0aa";
        public const string ArrowCircleDown = "\uf0ab";
        public const string Globe = "\uf0ac";
        public const string Wrench = "\uf0ad";
        public const string Tasks = "\uf0ae";
        public const string Filter = "\uf0b0";
        public const string Briefcase = "\uf0b1";
        public const string ArrowsAlt = "\uf0b2";
        public const string Users = "\uf0c0";
        public const string Link = "\uf0c1";
        public const string Cloud = "\uf0c2";
        public const string Flask = "\uf0c3";
        public const string Cut = "\uf0c4";
        public const string Copy = "\uf0c5";
        public const string Paperclip = "\uf0c6";
        public const string Save = "\uf0c7";
        public const string Square = "\uf0c8";
        public const string Bars = "\uf0c9";
        public const string ListUl = "\uf0ca";
        public const string ListOl = "\uf0cb";
        public const string Strikethrough = "\uf0cc";
        public const string Underline = "\uf0cd";
        public const string Table = "\uf0ce";
        public const string Magic = "\uf0d0";
        public const string Truck = "\uf0d1";
        public const string MoneyBill = "\uf0d6";
        public const string CaretDown = "\uf0d7";
        public const string CaretUp = "\uf0d8";
        public const string CaretLeft = "\uf0d9";
        public const string CaretRight = "\uf0da";
        public const string Columns = "\uf0db";
        public const string Sort = "\uf0dc";
        public const string SortDown = "\uf0dd";
        public const string SortUp = "\uf0de";
        public const string Envelope = "\uf0e0";
        public const string Undo = "\uf0e2";
        public const string Gavel = "\uf0e3";
        public const string Bolt = "\uf0e7";
        public const string Sitemap = "\uf0e8";
        public const string Umbrella = "\uf0e9";
        public const string Paste = "\uf0ea";
        public const string Lightbulb = "\uf0eb";
        public const string UserMd = "\uf0f0";
        public const string Stethoscope = "\uf0f1";
        public const string Suitcase = "\uf0f2";
        public const string Bell = "\uf0f3";
        public const string Coffee = "\uf0f4";
        public const string Hospital = "\uf0f8";
        public const string Ambulance = "\uf0f9";
        public const string Medkit = "\uf0fa";
        public const string FighterJet = "\uf0fb";
        public const string Beer = "\uf0fc";
        public const string HSquare = "\uf0fd";
        public const string PlusSquare = "\uf0fe";
        public const string AngleDoubleLeft = "\uf100";
        public const string AngleDoubleRight = "\uf101";
        public const string AngleDoubleUp = "\uf102";
        public const string AngleDoubleDown = "\uf103";
        public const string AngleLeft = "\uf104";
        public const string AngleRight = "\uf105";
        public const string AngleUp = "\uf106";
        public const string AngleDown = "\uf107";
        public const string Desktop = "\uf108";
        public const string Laptop = "\uf109";
        public const string Tablet = "\uf10a";
        public const string Mobile = "\uf10b";
        public const string QuoteLeft = "\uf10d";
        public const string QuoteRight = "\uf10e";
        public const string Spinner = "\uf110";
        public const string Circle = "\uf111";
        public const string Smile = "\uf118";
        public const string Frown = "\uf119";
        public const string Meh = "\uf11a";
        public const string Gamepad = "\uf11b";
        public const string Keyboard = "\uf11c";
        public const string FlagCheckered = "\uf11e";
        public const string Terminal = "\uf120";
        public const string Code = "\uf121";
        public const string ReplyAll = "\uf122";
        public const string LocationArrow = "\uf124";
        public const string Crop = "\uf125";
        public const string CodeBranch = "\uf126";
        public const string Unlink = "\uf127";
        public const string Question = "\uf128";
        public const string Info = "\uf129";
        public const string Exclamation = "\uf12a";
        public const string Superscript = "\uf12b";
        public const string Subscript = "\uf12c";
        public const string Eraser = "\uf12d";
        public const string PuzzlePiece = "\uf12e";
        public const string Microphone = "\uf130";
        public const string MicrophoneSlash = "\uf131";
        public const string Calendar = "\uf133";
        public const string FireExtinguisher = "\uf134";
        public const string Rocket = "\uf135";
        public const string ChevronCircleLeft = "\uf137";
        public const string ChevronCircleRight = "\uf138";
        public const string ChevronCircleUp = "\uf139";
        public const string ChevronCircleDown = "\uf13a";
        public const string Anchor = "\uf13d";
        public const string UnlockAlt = "\uf13e";
        public const string Bullseye = "\uf140";
        public const string EllipsisH = "\uf141";
        public const string EllipsisV = "\uf142";
        public const string RssSquare = "\uf143";
        public const string PlayCircle = "\uf144";
        public const string MinusSquare = "\uf146";
        public const string CheckSquare = "\uf14a";
        public const string PenSquare = "\uf14b";
        public const string ShareSquare = "\uf14d";
        public const string Compass = "\uf14e";
        public const string CaretSquareDown = "\uf150";
        public const string CaretSquareUp = "\uf151";
        public const string CaretSquareRight = "\uf152";
        public const string EuroSign = "\uf153";
        public const string PoundSign = "\uf154";
        public const string DollarSign = "\uf155";
        public const string RupeeSign = "\uf156";
        public const string YenSign = "\uf157";
        public const string RubleSign = "\uf158";
        public const string WonSign = "\uf159";
        public const string File = "\uf15b";
        public const string FileAlt = "\uf15c";
        public const string SortAlphaDown = "\uf15d";
        public const string SortAlphaUp = "\uf15e";
        public const string SortAmountDown = "\uf160";
        public const string SortAmountUp = "\uf161";
        public const string SortNumericDown = "\uf162";
        public const string SortNumericUp = "\uf163";
        public const string ThumbsUp = "\uf164";
        public const string ThumbsDown = "\uf165";
        public const string Female = "\uf182";
        public const string Male = "\uf183";
        public const string Sun = "\uf185";
        public const string Moon = "\uf186";
        public const string Archive = "\uf187";
        public const string Bug = "\uf188";
        public const string CaretSquareLeft = "\uf191";
        public const string DotCircle = "\uf192";
        public const string Wheelchair = "\uf193";
        public const string LiraSign = "\uf195";
        public const string SpaceShuttle = "\uf197";
        public const string EnvelopeSquare = "\uf199";
        public const string University = "\uf19c";
        public const string GraduationCap = "\uf19d";
        public const string Language = "\uf1ab";
        public const string Fax = "\uf1ac";
        public const string Building = "\uf1ad";
        public const string Child = "\uf1ae";
        public const string Paw = "\uf1b0";
        public const string Cube = "\uf1b2";
        public const string Cubes = "\uf1b3";
        public const string Recycle = "\uf1b8";
        public const string Car = "\uf1b9";
        public const string Taxi = "\uf1ba";
        public const string Tree = "\uf1bb";
        public const string Database = "\uf1c0";
        public const string FilePdf = "\uf1c1";
        public const string FileWord = "\uf1c2";
        public const string FileExcel = "\uf1c3";
        public const string FilePowerpoint = "\uf1c4";
        public const string FileImage = "\uf1c5";
        public const string FileArchive = "\uf1c6";
        public const string FileAudio = "\uf1c7";
        public const string FileVideo = "\uf1c8";
        public const string FileCode = "\uf1c9";
        public const string LifeRing = "\uf1cd";
        public const string CircleNotch = "\uf1ce";
        public const string PaperPlane = "\uf1d8";
        public const string History = "\uf1da";
        public const string Heading = "\uf1dc";
        public const string Paragraph = "\uf1dd";
        public const string SlidersH = "\uf1de";
        public const string ShareAlt = "\uf1e0";
        public const string ShareAltSquare = "\uf1e1";
        public const string Bomb = "\uf1e2";
        public const string Futbol = "\uf1e3";
        public const string Tty = "\uf1e4";
        public const string Binoculars = "\uf1e5";
        public const string Plug = "\uf1e6";
        public const string Newspaper = "\uf1ea";
        public const string Wifi = "\uf1eb";
        public const string Calculator = "\uf1ec";
        public const string BellSlash = "\uf1f6";
        public const string Trash = "\uf1f8";
        public const string Copyright = "\uf1f9";
        public const string At = "\uf1fa";
        public const string EyeDropper = "\uf1fb";
        public const string PaintBrush = "\uf1fc";
        public const string BirthdayCake = "\uf1fd";
        public const string ChartArea = "\uf1fe";
        public const string ChartPie = "\uf200";
        public const string ChartLine = "\uf201";
        public const string ToggleOff = "\uf204";
        public const string ToggleOn = "\uf205";
        public const string Bicycle = "\uf206";
        public const string Bus = "\uf207";
        public const string ClosedCaptioning = "\uf20a";
        public const string ShekelSign = "\uf20b";
        public const string CartPlus = "\uf217";
        public const string CartArrowDown = "\uf218";
        public const string Ship = "\uf21a";
        public const string UserSecret = "\uf21b";
        public const string Motorcycle = "\uf21c";
        public const string StreetView = "\uf21d";
        public const string Heartbeat = "\uf21e";
        public const string Venus = "\uf221";
        public const string Mars = "\uf222";
        public const string Mercury = "\uf223";
        public const string Transgender = "\uf224";
        public const string TransgenderAlt = "\uf225";
        public const string VenusDouble = "\uf226";
        public const string MarsDouble = "\uf227";
        public const string VenusMars = "\uf228";
        public const string MarsStroke = "\uf229";
        public const string MarsStrokeV = "\uf22a";
        public const string MarsStrokeH = "\uf22b";
        public const string Neuter = "\uf22c";
        public const string Genderless = "\uf22d";
        public const string Server = "\uf233";
        public const string UserPlus = "\uf234";
        public const string UserTimes = "\uf235";
        public const string Bed = "\uf236";
        public const string Train = "\uf238";
        public const string Subway = "\uf239";
        public const string BatteryFull = "\uf240";
        public const string BatteryThreeQuarters = "\uf241";
        public const string BatteryHalf = "\uf242";
        public const string BatteryQuarter = "\uf243";
        public const string BatteryEmpty = "\uf244";
        public const string MousePointer = "\uf245";
        public const string ICursor = "\uf246";
        public const string ObjectGroup = "\uf247";
        public const string ObjectUngroup = "\uf248";
        public const string StickyNote = "\uf249";
        public const string Clone = "\uf24d";
        public const string BalanceScale = "\uf24e";
        public const string HourglassStart = "\uf251";
        public const string HourglassHalf = "\uf252";
        public const string HourglassEnd = "\uf253";
        public const string Hourglass = "\uf254";
        public const string HandRock = "\uf255";
        public const string HandPaper = "\uf256";
        public const string HandScissors = "\uf257";
        public const string HandLizard = "\uf258";
        public const string HandSpock = "\uf259";
        public const string HandPointer = "\uf25a";
        public const string HandPeace = "\uf25b";
        public const string Trademark = "\uf25c";
        public const string Registered = "\uf25d";
        public const string Tv = "\uf26c";
        public const string CalendarPlus = "\uf271";
        public const string CalendarMinus = "\uf272";
        public const string CalendarTimes = "\uf273";
        public const string CalendarCheck = "\uf274";
        public const string Industry = "\uf275";
        public const string MapPin = "\uf276";
        public const string MapSigns = "\uf277";
        public const string Map = "\uf279";
        public const string CommentAlt = "\uf27a";
        public const string PauseCircle = "\uf28b";
        public const string StopCircle = "\uf28d";
        public const string ShoppingBag = "\uf290";
        public const string ShoppingBasket = "\uf291";
        public const string Hashtag = "\uf292";
        public const string Percent = "\uf295";
        public const string UniversalAccess = "\uf29a";
        public const string Blind = "\uf29d";
        public const string AudioDescription = "\uf29e";
        public const string PhoneVolume = "\uf2a0";
        public const string Braille = "\uf2a1";
        public const string AssistiveListeningSystems = "\uf2a2";
        public const string AmericanSignLanguageInterpreting = "\uf2a3";
        public const string Deaf = "\uf2a4";
        public const string SignLanguage = "\uf2a7";
        public const string LowVision = "\uf2a8";
        public const string Handshake = "\uf2b5";
        public const string EnvelopeOpen = "\uf2b6";
        public const string AddressBook = "\uf2b9";
        public const string AddressCard = "\uf2bb";
        public const string UserCircle = "\uf2bd";
        public const string IdBadge = "\uf2c1";
        public const string IdCard = "\uf2c2";
        public const string ThermometerFull = "\uf2c7";
        public const string ThermometerThreeQuarters = "\uf2c8";
        public const string ThermometerHalf = "\uf2c9";
        public const string ThermometerQuarter = "\uf2ca";
        public const string ThermometerEmpty = "\uf2cb";
        public const string Shower = "\uf2cc";
        public const string Bath = "\uf2cd";
        public const string Podcast = "\uf2ce";
        public const string WindowMaximize = "\uf2d0";
        public const string WindowMinimize = "\uf2d1";
        public const string WindowRestore = "\uf2d2";
        public const string Microchip = "\uf2db";
        public const string Snowflake = "\uf2dc";
        public const string UtensilSpoon = "\uf2e5";
        public const string Utensils = "\uf2e7";
        public const string UndoAlt = "\uf2ea";
        public const string TrashAlt = "\uf2ed";
        public const string SyncAlt = "\uf2f1";
        public const string Stopwatch = "\uf2f2";
        public const string SignOutAlt = "\uf2f5";
        public const string SignInAlt = "\uf2f6";
        public const string RedoAlt = "\uf2f9";
        public const string Poo = "\uf2fe";
        public const string Images = "\uf302";
        public const string PencilAlt = "\uf303";
        public const string Pen = "\uf304";
        public const string PenAlt = "\uf305";
        public const string LongArrowAltDown = "\uf309";
        public const string LongArrowAltLeft = "\uf30a";
        public const string LongArrowAltRight = "\uf30b";
        public const string LongArrowAltUp = "\uf30c";
        public const string ExpandArrowsAlt = "\uf31e";
        public const string Clipboard = "\uf328";
        public const string ArrowsAltH = "\uf337";
        public const string ArrowsAltV = "\uf338";
        public const string ArrowAltCircleDown = "\uf358";
        public const string ArrowAltCircleLeft = "\uf359";
        public const string ArrowAltCircleRight = "\uf35a";
        public const string ArrowAltCircleUp = "\uf35b";
        public const string ExternalLinkAlt = "\uf35d";
        public const string ExternalLinkSquareAlt = "\uf360";
        public const string ExchangeAlt = "\uf362";
        public const string CloudDownloadAlt = "\uf381";
        public const string CloudUploadAlt = "\uf382";
        public const string Gem = "\uf3a5";
        public const string LevelDownAlt = "\uf3be";
        public const string LevelUpAlt = "\uf3bf";
        public const string LockOpen = "\uf3c1";
        public const string MapMarkerAlt = "\uf3c5";
        public const string MicrophoneAlt = "\uf3c9";
        public const string MobileAlt = "\uf3cd";
        public const string MoneyBillAlt = "\uf3d1";
        public const string PhoneSlash = "\uf3dd";
        public const string Portrait = "\uf3e0";
        public const string Reply = "\uf3e5";
        public const string ShieldAlt = "\uf3ed";
        public const string TabletAlt = "\uf3fa";
        public const string TachometerAlt = "\uf3fd";
        public const string TicketAlt = "\uf3ff";
        public const string UserAlt = "\uf406";
        public const string WindowClose = "\uf410";
        public const string CompressAlt = "\uf422";
        public const string ExpandAlt = "\uf424";
        public const string BaseballBall = "\uf433";
        public const string BasketballBall = "\uf434";
        public const string BowlingBall = "\uf436";
        public const string Chess = "\uf439";
        public const string ChessBishop = "\uf43a";
        public const string ChessBoard = "\uf43c";
        public const string ChessKing = "\uf43f";
        public const string ChessKnight = "\uf441";
        public const string ChessPawn = "\uf443";
        public const string ChessQueen = "\uf445";
        public const string ChessRook = "\uf447";
        public const string Dumbbell = "\uf44b";
        public const string FootballBall = "\uf44e";
        public const string GolfBall = "\uf450";
        public const string HockeyPuck = "\uf453";
        public const string Quidditch = "\uf458";
        public const string SquareFull = "\uf45c";
        public const string TableTennis = "\uf45d";
        public const string VolleyballBall = "\uf45f";
        public const string Allergies = "\uf461";
        public const string BandAid = "\uf462";
        public const string Box = "\uf466";
        public const string Boxes = "\uf468";
        public const string BriefcaseMedical = "\uf469";
        public const string Burn = "\uf46a";
        public const string Capsules = "\uf46b";
        public const string ClipboardCheck = "\uf46c";
        public const string ClipboardList = "\uf46d";
        public const string Diagnoses = "\uf470";
        public const string Dna = "\uf471";
        public const string Dolly = "\uf472";
        public const string DollyFlatbed = "\uf474";
        public const string FileMedical = "\uf477";
        public const string FileMedicalAlt = "\uf478";
        public const string FirstAid = "\uf479";
        public const string HospitalAlt = "\uf47d";
        public const string HospitalSymbol = "\uf47e";
        public const string IdCardAlt = "\uf47f";
        public const string NotesMedical = "\uf481";
        public const string Pallet = "\uf482";
        public const string Pills = "\uf484";
        public const string PrescriptionBottle = "\uf485";
        public const string PrescriptionBottleAlt = "\uf486";
        public const string Procedures = "\uf487";
        public const string ShippingFast = "\uf48b";
        public const string Smoking = "\uf48d";
        public const string Syringe = "\uf48e";
        public const string Tablets = "\uf490";
        public const string Thermometer = "\uf491";
        public const string Vial = "\uf492";
        public const string Vials = "\uf493";
        public const string Warehouse = "\uf494";
        public const string Weight = "\uf496";
        public const string XRay = "\uf497";
        public const string BoxOpen = "\uf49e";
        public const string CommentDots = "\uf4ad";
        public const string CommentSlash = "\uf4b3";
        public const string Couch = "\uf4b8";
        public const string Donate = "\uf4b9";
        public const string Dove = "\uf4ba";
        public const string HandHolding = "\uf4bd";
        public const string HandHoldingHeart = "\uf4be";
        public const string HandHoldingUsd = "\uf4c0";
        public const string Hands = "\uf4c2";
        public const string HandsHelping = "\uf4c4";
        public const string ParachuteBox = "\uf4cd";
        public const string PeopleCarry = "\uf4ce";
        public const string PiggyBank = "\uf4d3";
        public const string Ribbon = "\uf4d6";
        public const string Route = "\uf4d7";
        public const string Seedling = "\uf4d8";
        public const string Sign = "\uf4d9";
        public const string SmileWink = "\uf4da";
        public const string Tape = "\uf4db";
        public const string TruckLoading = "\uf4de";
        public const string TruckMoving = "\uf4df";
        public const string VideoSlash = "\uf4e2";
        public const string WineGlass = "\uf4e3";
        public const string UserAltSlash = "\uf4fa";
        public const string UserAstronaut = "\uf4fb";
        public const string UserCheck = "\uf4fc";
        public const string UserClock = "\uf4fd";
        public const string UserCog = "\uf4fe";
        public const string UserEdit = "\uf4ff";
        public const string UserFriends = "\uf500";
        public const string UserGraduate = "\uf501";
        public const string UserLock = "\uf502";
        public const string UserMinus = "\uf503";
        public const string UserNinja = "\uf504";
        public const string UserShield = "\uf505";
        public const string UserSlash = "\uf506";
        public const string UserTag = "\uf507";
        public const string UserTie = "\uf508";
        public const string UsersCog = "\uf509";
        public const string BalanceScaleLeft = "\uf515";
        public const string BalanceScaleRight = "\uf516";
        public const string Blender = "\uf517";
        public const string BookOpen = "\uf518";
        public const string BroadcastTower = "\uf519";
        public const string Broom = "\uf51a";
        public const string Chalkboard = "\uf51b";
        public const string ChalkboardTeacher = "\uf51c";
        public const string Church = "\uf51d";
        public const string Coins = "\uf51e";
        public const string CompactDisc = "\uf51f";
        public const string Crow = "\uf520";
        public const string Crown = "\uf521";
        public const string Dice = "\uf522";
        public const string DiceFive = "\uf523";
        public const string DiceFour = "\uf524";
        public const string DiceOne = "\uf525";
        public const string DiceSix = "\uf526";
        public const string DiceThree = "\uf527";
        public const string DiceTwo = "\uf528";
        public const string Divide = "\uf529";
        public const string DoorClosed = "\uf52a";
        public const string DoorOpen = "\uf52b";
        public new const string Equals = "\uf52c";
        public const string Feather = "\uf52d";
        public const string Frog = "\uf52e";
        public const string GasPump = "\uf52f";
        public const string Glasses = "\uf530";
        public const string GreaterThan = "\uf531";
        public const string GreaterThanEqual = "\uf532";
        public const string Helicopter = "\uf533";
        public const string Infinity = "\uf534";
        public const string KiwiBird = "\uf535";
        public const string LessThan = "\uf536";
        public const string LessThanEqual = "\uf537";
        public const string Memory = "\uf538";
        public const string MicrophoneAltSlash = "\uf539";
        public const string MoneyBillWave = "\uf53a";
        public const string MoneyBillWaveAlt = "\uf53b";
        public const string MoneyCheck = "\uf53c";
        public const string MoneyCheckAlt = "\uf53d";
        public const string NotEqual = "\uf53e";
        public const string Palette = "\uf53f";
        public const string Parking = "\uf540";
        public const string Percentage = "\uf541";
        public const string ProjectDiagram = "\uf542";
        public const string Receipt = "\uf543";
        public const string Robot = "\uf544";
        public const string Ruler = "\uf545";
        public const string RulerCombined = "\uf546";
        public const string RulerHorizontal = "\uf547";
        public const string RulerVertical = "\uf548";
        public const string School = "\uf549";
        public const string Screwdriver = "\uf54a";
        public const string ShoePrints = "\uf54b";
        public const string Skull = "\uf54c";
        public const string SmokingBan = "\uf54d";
        public const string Store = "\uf54e";
        public const string StoreAlt = "\uf54f";
        public const string Stream = "\uf550";
        public const string Stroopwafel = "\uf551";
        public const string Toolbox = "\uf552";
        public const string Tshirt = "\uf553";
        public const string Walking = "\uf554";
        public const string Wallet = "\uf555";
        public const string Angry = "\uf556";
        public const string Archway = "\uf557";
        public const string Atlas = "\uf558";
        public const string Award = "\uf559";
        public const string Backspace = "\uf55a";
        public const string BezierCurve = "\uf55b";
        public const string Bong = "\uf55c";
        public const string Brush = "\uf55d";
        public const string BusAlt = "\uf55e";
        public const string Cannabis = "\uf55f";
        public const string CheckDouble = "\uf560";
        public const string Cocktail = "\uf561";
        public const string ConciergeBell = "\uf562";
        public const string Cookie = "\uf563";
        public const string CookieBite = "\uf564";
        public const string CropAlt = "\uf565";
        public const string DigitalTachograph = "\uf566";
        public const string Dizzy = "\uf567";
        public const string DraftingCompass = "\uf568";
        public const string Drum = "\uf569";
        public const string DrumSteelpan = "\uf56a";
        public const string FeatherAlt = "\uf56b";
        public const string FileContract = "\uf56c";
        public const string FileDownload = "\uf56d";
        public const string FileExport = "\uf56e";
        public const string FileImport = "\uf56f";
        public const string FileInvoice = "\uf570";
        public const string FileInvoiceDollar = "\uf571";
        public const string FilePrescription = "\uf572";
        public const string FileSignature = "\uf573";
        public const string FileUpload = "\uf574";
        public const string Fill = "\uf575";
        public const string FillDrip = "\uf576";
        public const string Fingerprint = "\uf577";
        public const string Fish = "\uf578";
        public const string Flushed = "\uf579";
        public const string FrownOpen = "\uf57a";
        public const string GlassMartiniAlt = "\uf57b";
        public const string GlobeAfrica = "\uf57c";
        public const string GlobeAmericas = "\uf57d";
        public const string GlobeAsia = "\uf57e";
        public const string Grimace = "\uf57f";
        public const string Grin = "\uf580";
        public const string GrinAlt = "\uf581";
        public const string GrinBeam = "\uf582";
        public const string GrinBeamSweat = "\uf583";
        public const string GrinHearts = "\uf584";
        public const string GrinSquint = "\uf585";
        public const string GrinSquintTears = "\uf586";
        public const string GrinStars = "\uf587";
        public const string GrinTears = "\uf588";
        public const string GrinTongue = "\uf589";
        public const string GrinTongueSquint = "\uf58a";
        public const string GrinTongueWink = "\uf58b";
        public const string GrinWink = "\uf58c";
        public const string GripHorizontal = "\uf58d";
        public const string GripVertical = "\uf58e";
        public const string HeadphonesAlt = "\uf58f";
        public const string Headset = "\uf590";
        public const string Highlighter = "\uf591";
        public const string HotTub = "\uf593";
        public const string Hotel = "\uf594";
        public const string Joint = "\uf595";
        public const string Kiss = "\uf596";
        public const string KissBeam = "\uf597";
        public const string KissWinkHeart = "\uf598";
        public const string Laugh = "\uf599";
        public const string LaughBeam = "\uf59a";
        public const string LaughSquint = "\uf59b";
        public const string LaughWink = "\uf59c";
        public const string LuggageCart = "\uf59d";
        public const string MapMarked = "\uf59f";
        public const string MapMarkedAlt = "\uf5a0";
        public const string Marker = "\uf5a1";
        public const string Medal = "\uf5a2";
        public const string MehBlank = "\uf5a4";
        public const string MehRollingEyes = "\uf5a5";
        public const string Monument = "\uf5a6";
        public const string MortarPestle = "\uf5a7";
        public const string PaintRoller = "\uf5aa";
        public const string Passport = "\uf5ab";
        public const string PenFancy = "\uf5ac";
        public const string PenNib = "\uf5ad";
        public const string PencilRuler = "\uf5ae";
        public const string PlaneArrival = "\uf5af";
        public const string PlaneDeparture = "\uf5b0";
        public const string Prescription = "\uf5b1";
        public const string SadCry = "\uf5b3";
        public const string SadTear = "\uf5b4";
        public const string ShuttleVan = "\uf5b6";
        public const string Signature = "\uf5b7";
        public const string SmileBeam = "\uf5b8";
        public const string SolarPanel = "\uf5ba";
        public const string Spa = "\uf5bb";
        public const string Splotch = "\uf5bc";
        public const string SprayCan = "\uf5bd";
        public const string Stamp = "\uf5bf";
        public const string StarHalfAlt = "\uf5c0";
        public const string SuitcaseRolling = "\uf5c1";
        public const string Surprise = "\uf5c2";
        public const string Swatchbook = "\uf5c3";
        public const string Swimmer = "\uf5c4";
        public const string SwimmingPool = "\uf5c5";
        public const string TintSlash = "\uf5c7";
        public const string Tired = "\uf5c8";
        public const string Tooth = "\uf5c9";
        public const string UmbrellaBeach = "\uf5ca";
        public const string VectorSquare = "\uf5cb";
        public const string WeightHanging = "\uf5cd";
        public const string WineGlassAlt = "\uf5ce";
        public const string AirFreshener = "\uf5d0";
        public const string AppleAlt = "\uf5d1";
        public const string Atom = "\uf5d2";
        public const string Bone = "\uf5d7";
        public const string BookReader = "\uf5da";
        public const string Brain = "\uf5dc";
        public const string CarAlt = "\uf5de";
        public const string CarBattery = "\uf5df";
        public const string CarCrash = "\uf5e1";
        public const string CarSide = "\uf5e4";
        public const string ChargingStation = "\uf5e7";
        public const string Directions = "\uf5eb";
        public const string DrawPolygon = "\uf5ee";
        public const string LaptopCode = "\uf5fc";
        public const string LayerGroup = "\uf5fd";
        public const string Microscope = "\uf610";
        public const string OilCan = "\uf613";
        public const string Poop = "\uf619";
        public const string Shapes = "\uf61f";
        public const string StarOfLife = "\uf621";
        public const string Teeth = "\uf62e";
        public const string TeethOpen = "\uf62f";
        public const string TheaterMasks = "\uf630";
        public const string TrafficLight = "\uf637";
        public const string TruckMonster = "\uf63b";
        public const string TruckPickup = "\uf63c";
        public const string Ad = "\uf641";
        public const string Ankh = "\uf644";
        public const string Bible = "\uf647";
        public const string BusinessTime = "\uf64a";
        public const string City = "\uf64f";
        public const string CommentDollar = "\uf651";
        public const string CommentsDollar = "\uf653";
        public const string Cross = "\uf654";
        public const string Dharmachakra = "\uf655";
        public const string EnvelopeOpenText = "\uf658";
        public const string FolderMinus = "\uf65d";
        public const string FolderPlus = "\uf65e";
        public const string FunnelDollar = "\uf662";
        public const string Gopuram = "\uf664";
        public const string Hamsa = "\uf665";
        public const string Bahai = "\uf666";
        public const string Jedi = "\uf669";
        public const string JournalWhills = "\uf66a";
        public const string Kaaba = "\uf66b";
        public const string Khanda = "\uf66d";
        public const string Landmark = "\uf66f";
        public const string MailBulk = "\uf674";
        public const string Menorah = "\uf676";
        public const string Mosque = "\uf678";
        public const string Om = "\uf679";
        public const string Pastafarianism = "\uf67b";
        public const string Peace = "\uf67c";
        public const string PlaceOfWorship = "\uf67f";
        public const string Poll = "\uf681";
        public const string PollH = "\uf682";
        public const string Pray = "\uf683";
        public const string PrayingHands = "\uf684";
        public const string Quran = "\uf687";
        public const string SearchDollar = "\uf688";
        public const string SearchLocation = "\uf689";
        public const string Socks = "\uf696";
        public const string SquareRootAlt = "\uf698";
        public const string StarAndCrescent = "\uf699";
        public const string StarOfDavid = "\uf69a";
        public const string Synagogue = "\uf69b";
        public const string Torah = "\uf6a0";
        public const string ToriiGate = "\uf6a1";
        public const string Vihara = "\uf6a7";
        public const string VolumeMute = "\uf6a9";
        public const string YinYang = "\uf6ad";
        public const string BlenderPhone = "\uf6b6";
        public const string BookDead = "\uf6b7";
        public const string Campground = "\uf6bb";
        public const string Cat = "\uf6be";
        public const string Chair = "\uf6c0";
        public const string CloudMoon = "\uf6c3";
        public const string CloudSun = "\uf6c4";
        public const string DiceD20 = "\uf6cf";
        public const string DiceD6 = "\uf6d1";
        public const string Dog = "\uf6d3";
        public const string Dragon = "\uf6d5";
        public const string DrumstickBite = "\uf6d7";
        public const string Dungeon = "\uf6d9";
        public const string FileCsv = "\uf6dd";
        public const string FistRaised = "\uf6de";
        public const string Ghost = "\uf6e2";
        public const string Hammer = "\uf6e3";
        public const string Hanukiah = "\uf6e6";
        public const string HatWizard = "\uf6e8";
        public const string Hiking = "\uf6ec";
        public const string Hippo = "\uf6ed";
        public const string Horse = "\uf6f0";
        public const string HouseDamage = "\uf6f1";
        public const string Hryvnia = "\uf6f2";
        public const string Mask = "\uf6fa";
        public const string Mountain = "\uf6fc";
        public const string NetworkWired = "\uf6ff";
        public const string Otter = "\uf700";
        public const string Ring = "\uf70b";
        public const string Running = "\uf70c";
        public const string Scroll = "\uf70e";
        public const string SkullCrossbones = "\uf714";
        public const string Slash = "\uf715";
        public const string Spider = "\uf717";
        public const string ToiletPaper = "\uf71e";
        public const string Tractor = "\uf722";
        public const string UserInjured = "\uf728";
        public const string VrCardboard = "\uf729";
        public const string Wind = "\uf72e";
        public const string WineBottle = "\uf72f";
        public const string CloudMeatball = "\uf73b";
        public const string CloudMoonRain = "\uf73c";
        public const string CloudRain = "\uf73d";
        public const string CloudShowersHeavy = "\uf740";
        public const string CloudSunRain = "\uf743";
        public const string Democrat = "\uf747";
        public const string FlagUsa = "\uf74d";
        public const string Meteor = "\uf753";
        public const string PersonBooth = "\uf756";
        public const string PooStorm = "\uf75a";
        public const string Rainbow = "\uf75b";
        public const string Republican = "\uf75e";
        public const string Smog = "\uf75f";
        public const string TemperatureHigh = "\uf769";
        public const string TemperatureLow = "\uf76b";
        public const string VoteYea = "\uf772";
        public const string Water = "\uf773";
        public const string Baby = "\uf77c";
        public const string BabyCarriage = "\uf77d";
        public const string Biohazard = "\uf780";
        public const string Blog = "\uf781";
        public const string CalendarDay = "\uf783";
        public const string CalendarWeek = "\uf784";
        public const string CandyCane = "\uf786";
        public const string Carrot = "\uf787";
        public const string CashRegister = "\uf788";
        public const string CompressArrowsAlt = "\uf78c";
        public const string Dumpster = "\uf793";
        public const string DumpsterFire = "\uf794";
        public const string Ethernet = "\uf796";
        public const string Gifts = "\uf79c";
        public const string GlassCheers = "\uf79f";
        public const string GlassWhiskey = "\uf7a0";
        public const string GlobeEurope = "\uf7a2";
        public const string GripLines = "\uf7a4";
        public const string GripLinesVertical = "\uf7a5";
        public const string Guitar = "\uf7a6";
        public const string HeartBroken = "\uf7a9";
        public const string HollyBerry = "\uf7aa";
        public const string HorseHead = "\uf7ab";
        public const string Icicles = "\uf7ad";
        public const string Igloo = "\uf7ae";
        public const string Mitten = "\uf7b5";
        public const string MugHot = "\uf7b6";
        public const string Radiation = "\uf7b9";
        public const string RadiationAlt = "\uf7ba";
        public const string Restroom = "\uf7bd";
        public const string Satellite = "\uf7bf";
        public const string SatelliteDish = "\uf7c0";
        public const string SdCard = "\uf7c2";
        public const string SimCard = "\uf7c4";
        public const string Skating = "\uf7c5";
        public const string Skiing = "\uf7c9";
        public const string SkiingNordic = "\uf7ca";
        public const string Sleigh = "\uf7cc";
        public const string Sms = "\uf7cd";
        public const string Snowboarding = "\uf7ce";
        public const string Snowman = "\uf7d0";
        public const string Snowplow = "\uf7d2";
        public const string Tenge = "\uf7d7";
        public const string Toilet = "\uf7d8";
        public const string Tools = "\uf7d9";
        public const string Tram = "\uf7da";
        public const string FireAlt = "\uf7e4";
        public const string Bacon = "\uf7e5";
        public const string BookMedical = "\uf7e6";
        public const string BreadSlice = "\uf7ec";
        public const string Cheese = "\uf7ef";
        public const string ClinicMedical = "\uf7f2";
        public const string CommentMedical = "\uf7f5";
        public const string Crutch = "\uf7f7";
        public const string Egg = "\uf7fb";
        public const string Hamburger = "\uf805";
        public const string HandMiddleFinger = "\uf806";
        public const string HardHat = "\uf807";
        public const string Hotdog = "\uf80f";
        public const string IceCream = "\uf810";
        public const string LaptopMedical = "\uf812";
        public const string Pager = "\uf815";
        public const string PepperHot = "\uf816";
        public const string PizzaSlice = "\uf818";
        public const string TrashRestore = "\uf829";
        public const string TrashRestoreAlt = "\uf82a";
        public const string UserNurse = "\uf82f";
        public const string WaveSquare = "\uf83e";
        public const string Biking = "\uf84a";
        public const string BorderAll = "\uf84c";
        public const string BorderNone = "\uf850";
        public const string BorderStyle = "\uf853";
        public const string Fan = "\uf863";
        public const string Icons = "\uf86d";
        public const string PhoneAlt = "\uf879";
        public const string PhoneSquareAlt = "\uf87b";
        public const string PhotoVideo = "\uf87c";
        public const string RemoveFormat = "\uf87d";
        public const string SortAlphaDownAlt = "\uf881";
        public const string SortAlphaUpAlt = "\uf882";
        public const string SortAmountDownAlt = "\uf884";
        public const string SortAmountUpAlt = "\uf885";
        public const string SortNumericDownAlt = "\uf886";
        public const string SortNumericUpAlt = "\uf887";
        public const string SpellCheck = "\uf891";
        public const string Voicemail = "\uf897";
        public const string HatCowboy = "\uf8c0";
        public const string HatCowboySide = "\uf8c1";
        public const string Mouse = "\uf8cc";
        public const string RecordVinyl = "\uf8d9";
        public const string Caravan = "\uf8ff";
        public const string Trailer = "\uf941";
    }
}
