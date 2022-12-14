PGDMP     #    8            
    z            PruebaTecnica    12.7 (Debian 12.7-1.pgdg90+1)    12.2     _           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            `           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            a           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            b           1262    16384    PruebaTecnica    DATABASE        CREATE DATABASE "PruebaTecnica" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'en_US.utf8' LC_CTYPE = 'en_US.utf8';
    DROP DATABASE "PruebaTecnica";
                postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                postgres    false            c           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                   postgres    false    3            ?            1255    16454    servicios(numeric)    FUNCTION       CREATE FUNCTION public.servicios(id numeric) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
	declare
		resp bool;
	begin
		
		resp := (select s.estado from public.servicio s where s.estado = true and s.idconductor = id);
		
		return resp ;
	END;

$$;
 ,   DROP FUNCTION public.servicios(id numeric);
       public          Admin    false    3            ?            1259    16433 	   billetera    TABLE     ?   CREATE TABLE public.billetera (
    idbilletera numeric NOT NULL,
    nrotarjeta character varying(250),
    cv character varying(250),
    fechavencimiento character varying(5),
    idusuario numeric
);
    DROP TABLE public.billetera;
       public         heap    Admin    false    3            ?            1259    16391 	   conductor    TABLE     ?   CREATE TABLE public.conductor (
    id numeric(10,0) NOT NULL,
    nombrecompleto character varying(100) NOT NULL,
    vehiculo numeric(10,0)
);
    DROP TABLE public.conductor;
       public         heap    Admin    false    3            ?            1259    16419 	   recorrido    TABLE       CREATE TABLE public.recorrido (
    id numeric(100,0) NOT NULL,
    latitudorigen character varying(250) NOT NULL,
    longitudorigen character varying(250) NOT NULL,
    latituddestino character varying(250) NOT NULL,
    longituddestino character varying(250) NOT NULL
);
    DROP TABLE public.recorrido;
       public         heap    Admin    false    3            ?            1259    16441    sec_billetera_indice    SEQUENCE        CREATE SEQUENCE public.sec_billetera_indice
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000
    CACHE 1;
 +   DROP SEQUENCE public.sec_billetera_indice;
       public          Admin    false    3            ?            1259    16427    sec_recorrido_indice    SEQUENCE        CREATE SEQUENCE public.sec_recorrido_indice
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000
    CACHE 1;
 +   DROP SEQUENCE public.sec_recorrido_indice;
       public          Admin    false    3            ?            1259    16431    sec_servicio_indice    SEQUENCE     ~   CREATE SEQUENCE public.sec_servicio_indice
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000
    CACHE 1;
 *   DROP SEQUENCE public.sec_servicio_indice;
       public          Admin    false    3            ?            1259    16386    servicio    TABLE     ?   CREATE TABLE public.servicio (
    idconductor numeric(10,0),
    idpasajero numeric(10,0),
    idrecorrido numeric(10,0),
    idservicio numeric(10,0) NOT NULL,
    estado boolean
);
    DROP TABLE public.servicio;
       public         heap    Admin    false    3            ?            1259    16396    usuario    TABLE     s   CREATE TABLE public.usuario (
    id numeric(10,0) NOT NULL,
    nombrecompleto character varying(100) NOT NULL
);
    DROP TABLE public.usuario;
       public         heap    Admin    false    3            [          0    16433 	   billetera 
   TABLE DATA                 public          Admin    false    208            V          0    16391 	   conductor 
   TABLE DATA                 public          Admin    false    203            X          0    16419 	   recorrido 
   TABLE DATA                 public          Admin    false    205            U          0    16386    servicio 
   TABLE DATA                 public          Admin    false    202            W          0    16396    usuario 
   TABLE DATA                 public          Admin    false    204            d           0    0    sec_billetera_indice    SEQUENCE SET     B   SELECT pg_catalog.setval('public.sec_billetera_indice', 2, true);
          public          Admin    false    209            e           0    0    sec_recorrido_indice    SEQUENCE SET     B   SELECT pg_catalog.setval('public.sec_recorrido_indice', 9, true);
          public          Admin    false    206            f           0    0    sec_servicio_indice    SEQUENCE SET     A   SELECT pg_catalog.setval('public.sec_servicio_indice', 1, true);
          public          Admin    false    207            ?
           2606    16440    billetera billetera_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public.billetera
    ADD CONSTRAINT billetera_pkey PRIMARY KEY (idbilletera);
 B   ALTER TABLE ONLY public.billetera DROP CONSTRAINT billetera_pkey;
       public            Admin    false    208            ?
           2606    16395    conductor conductor_key 
   CONSTRAINT     U   ALTER TABLE ONLY public.conductor
    ADD CONSTRAINT conductor_key PRIMARY KEY (id);
 A   ALTER TABLE ONLY public.conductor DROP CONSTRAINT conductor_key;
       public            Admin    false    203            ?
           2606    16426    recorrido recorrido_key 
   CONSTRAINT     U   ALTER TABLE ONLY public.recorrido
    ADD CONSTRAINT recorrido_key PRIMARY KEY (id);
 A   ALTER TABLE ONLY public.recorrido DROP CONSTRAINT recorrido_key;
       public            Admin    false    205            ?
           2606    16402    servicio servicio_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.servicio
    ADD CONSTRAINT servicio_pkey PRIMARY KEY (idservicio);
 @   ALTER TABLE ONLY public.servicio DROP CONSTRAINT servicio_pkey;
       public            Admin    false    202            ?
           2606    16400    usuario usuario_key 
   CONSTRAINT     Q   ALTER TABLE ONLY public.usuario
    ADD CONSTRAINT usuario_key PRIMARY KEY (id);
 =   ALTER TABLE ONLY public.usuario DROP CONSTRAINT usuario_key;
       public            Admin    false    204            [     x???=K?A?????SAt???n?ڻۅ?D0?^?"?BD??o?-솁y???n??e?;<,߯??????tz?z?|Y???)??%^/?g?VfL+Xm??6A??A??G??n!<\	???X?*?b????X????98{s`Ǥ??t?a֢i֬^?? ??W???b????f??eMή΅?r?Z???ĕ=??HI?P??PcfT??:yL??=??4aj]???	\?f?C??ƀ?h?;??_?+6?7?]?      V   ?   x??ϱ?0@ѝ?x??b?'?&A?gې?bm?^???'???o??n??_?ᬌ"8??????#???55%?o?FN?@???oAHB$????m@?+Tn??e?f%???ѥV?I????????^-??ԧ?ɲ=?T?      X   ?  x??S?ja??S?m4?u??C?`?`?"??
;ά??m???????ۻ?/?Ǜ???????z|?z???????????㧯?w?7??x???̨.??_ߣ???2ȁ???<k҉?nj???o??????f??!?!c剖??=$T+rf?WrGU??綪v??????^?Π?Y???l?cT??JJ???h??ĩu[V!40?#w/??uL?˅ic?-BW???bj??2!f?&??Hֈ[??Th??mU???T??????̗"? ?? ?bf-`@????[???r$av????t?J?8?`???疪D-?;4??}"?"~E???9???I????S??뤚2ӑ:??T?(?????:?_!Π??9[!y?S?4Wz/?Q?/T?6;ͦ??˵??p?	      U   v   x???v
Q???W((M??L?+N-*?L??Ws?	uV?044453??01?Q??-?l0*)*Mմ??$? C?N#ccS3sK?AF`???SL?I?Fh&??(?j??	6?Y?(? L?? ?N?      W   ?   x???v
Q???W((M??L?+-.M,??Ws?	uV?0??453??0??QP?J??LKK-R??/N??W״??$?CC$#Js?R9?y)?U?E??adllbjfn	1"??43O!917?(?hWYX??H???MMI-VH?L,?? ??P?          _           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            `           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            a           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            b           1262    16384    PruebaTecnica    DATABASE        CREATE DATABASE "PruebaTecnica" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'en_US.utf8' LC_CTYPE = 'en_US.utf8';
    DROP DATABASE "PruebaTecnica";
                postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                postgres    false            c           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                   postgres    false    3            ?            1255    16454    servicios(numeric)    FUNCTION       CREATE FUNCTION public.servicios(id numeric) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
	declare
		resp bool;
	begin
		
		resp := (select s.estado from public.servicio s where s.estado = true and s.idconductor = id);
		
		return resp ;
	END;

$$;
 ,   DROP FUNCTION public.servicios(id numeric);
       public          Admin    false    3            ?            1259    16433 	   billetera    TABLE     ?   CREATE TABLE public.billetera (
    idbilletera numeric NOT NULL,
    nrotarjeta character varying(250),
    cv character varying(250),
    fechavencimiento character varying(5),
    idusuario numeric
);
    DROP TABLE public.billetera;
       public         heap    Admin    false    3            ?            1259    16391 	   conductor    TABLE     ?   CREATE TABLE public.conductor (
    id numeric(10,0) NOT NULL,
    nombrecompleto character varying(100) NOT NULL,
    vehiculo numeric(10,0)
);
    DROP TABLE public.conductor;
       public         heap    Admin    false    3            ?            1259    16419 	   recorrido    TABLE       CREATE TABLE public.recorrido (
    id numeric(100,0) NOT NULL,
    latitudorigen character varying(250) NOT NULL,
    longitudorigen character varying(250) NOT NULL,
    latituddestino character varying(250) NOT NULL,
    longituddestino character varying(250) NOT NULL
);
    DROP TABLE public.recorrido;
       public         heap    Admin    false    3            ?            1259    16441    sec_billetera_indice    SEQUENCE        CREATE SEQUENCE public.sec_billetera_indice
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000
    CACHE 1;
 +   DROP SEQUENCE public.sec_billetera_indice;
       public          Admin    false    3            ?            1259    16427    sec_recorrido_indice    SEQUENCE        CREATE SEQUENCE public.sec_recorrido_indice
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000
    CACHE 1;
 +   DROP SEQUENCE public.sec_recorrido_indice;
       public          Admin    false    3            ?            1259    16431    sec_servicio_indice    SEQUENCE     ~   CREATE SEQUENCE public.sec_servicio_indice
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000
    CACHE 1;
 *   DROP SEQUENCE public.sec_servicio_indice;
       public          Admin    false    3            ?            1259    16386    servicio    TABLE     ?   CREATE TABLE public.servicio (
    idconductor numeric(10,0),
    idpasajero numeric(10,0),
    idrecorrido numeric(10,0),
    idservicio numeric(10,0) NOT NULL,
    estado boolean
);
    DROP TABLE public.servicio;
       public         heap    Admin    false    3            ?            1259    16396    usuario    TABLE     s   CREATE TABLE public.usuario (
    id numeric(10,0) NOT NULL,
    nombrecompleto character varying(100) NOT NULL
);
    DROP TABLE public.usuario;
       public         heap    Admin    false    3            [          0    16433 	   billetera 
   TABLE DATA                 public          Admin    false    208            V          0    16391 	   conductor 
   TABLE DATA                 public          Admin    false    203          X          0    16419 	   recorrido 
   TABLE DATA                 public          Admin    false    205   ?        U          0    16386    servicio 
   TABLE DATA                 public          Admin    false    202   ?       W          0    16396    usuario 
   TABLE DATA                 public          Admin    false    204   ?        d           0    0    sec_billetera_indice    SEQUENCE SET     B   SELECT pg_catalog.setval('public.sec_billetera_indice', 2, true);
          public          Admin    false    209            e           0    0    sec_recorrido_indice    SEQUENCE SET     B   SELECT pg_catalog.setval('public.sec_recorrido_indice', 9, true);
          public          Admin    false    206            f           0    0    sec_servicio_indice    SEQUENCE SET     A   SELECT pg_catalog.setval('public.sec_servicio_indice', 1, true);
          public          Admin    false    207            ?
           2606    16440    billetera billetera_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public.billetera
    ADD CONSTRAINT billetera_pkey PRIMARY KEY (idbilletera);
 B   ALTER TABLE ONLY public.billetera DROP CONSTRAINT billetera_pkey;
       public            Admin    false    208            ?
           2606    16395    conductor conductor_key 
   CONSTRAINT     U   ALTER TABLE ONLY public.conductor
    ADD CONSTRAINT conductor_key PRIMARY KEY (id);
 A   ALTER TABLE ONLY public.conductor DROP CONSTRAINT conductor_key;
       public            Admin    false    203            ?
           2606    16426    recorrido recorrido_key 
   CONSTRAINT     U   ALTER TABLE ONLY public.recorrido
    ADD CONSTRAINT recorrido_key PRIMARY KEY (id);
 A   ALTER TABLE ONLY public.recorrido DROP CONSTRAINT recorrido_key;
       public            Admin    false    205            ?
           2606    16402    servicio servicio_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.servicio
    ADD CONSTRAINT servicio_pkey PRIMARY KEY (idservicio);
 @   ALTER TABLE ONLY public.servicio DROP CONSTRAINT servicio_pkey;
       public            Admin    false    202            ?
           2606    16400    usuario usuario_key 
   CONSTRAINT     Q   ALTER TABLE ONLY public.usuario
    ADD CONSTRAINT usuario_key PRIMARY KEY (id);
 =   ALTER TABLE ONLY public.usuario DROP CONSTRAINT usuario_key;
       public            Admin    false    204           