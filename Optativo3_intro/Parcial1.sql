PGDMP      2                |         	   optativo3    16.2    16.2 
    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16398 	   optativo3    DATABASE     |   CREATE DATABASE optativo3 WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Spain.1252';
    DROP DATABASE optativo3;
                postgres    false            �            1259    16399    cliente    TABLE     ^  CREATE TABLE public.cliente (
    id bigint NOT NULL,
    id_banco bigint NOT NULL,
    nombre character varying(255) NOT NULL,
    apellido character varying(255) NOT NULL,
    documento numeric NOT NULL,
    direccion character varying(255),
    mail character varying(255),
    celular character varying(255),
    estado character varying(255)
);
    DROP TABLE public.cliente;
       public         heap    postgres    false            �            1259    16406    factura    TABLE     f  CREATE TABLE public.factura (
    id bigint NOT NULL,
    id_cliente bigint NOT NULL,
    nro_factura character varying(255) NOT NULL,
    fecha_hora time with time zone,
    total double precision,
    total_iva5 double precision,
    total_iva10 double precision,
    total_iva double precision,
    total_letras numeric,
    sucursal character varying
);
    DROP TABLE public.factura;
       public         heap    postgres    false            �          0    16399    cliente 
   TABLE DATA           n   COPY public.cliente (id, id_banco, nombre, apellido, documento, direccion, mail, celular, estado) FROM stdin;
    public          postgres    false    215   �       �          0    16406    factura 
   TABLE DATA           �   COPY public.factura (id, id_cliente, nro_factura, fecha_hora, total, total_iva5, total_iva10, total_iva, total_letras, sucursal) FROM stdin;
    public          postgres    false    216          T           2606    16405    cliente cliente_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.cliente
    ADD CONSTRAINT cliente_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.cliente DROP CONSTRAINT cliente_pkey;
       public            postgres    false    215            V           2606    16412    factura factura_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT factura_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.factura DROP CONSTRAINT factura_pkey;
       public            postgres    false    216            �   S   x�3�4��*M��H-J�RN,J�I�4153�0�L,.�K����,(*MMJtH�M���K���4066255�tL.�,������ ]�      �      x������ � �     