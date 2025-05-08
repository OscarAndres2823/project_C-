CREATE DATABASE soe;
USE soe;

CREATE TABLE pais (
	id INT PRIMARY KEY,
	nombre VARCHAR(50)
);

CREATE TABLE region (
	id INT PRIMARY KEY,
	nombre VARCHAR(50),
	pais_id INT,
	FOREIGN KEY (pais_id) REFERENCES pais(id)
);

CREATE TABLE ciudad (
	id INT PRIMARY KEY,
	nombre VARCHAR(50),
	region_id INT,
	FOREIGN KEY (region_id) REFERENCES region(id)
);

CREATE TABLE empresa (
	id INT PRIMARY KEY,
	nombre VARCHAR(50),
	ciudad_id INT,
	FOREIGN KEY (ciudad_id) REFERENCES ciudad(id)
);

CREATE TABLE tipo_documento (
	id INT PRIMARY KEY,
	descripcion VARCHAR(50)
);

CREATE TABLE tipo_tercero (
	id INT PRIMARY KEY,
	descripcion VARCHAR(50)
);

CREATE TABLE tercero (
	id INT PRIMARY KEY,
	nombre VARCHAR(50),
	apellidos VARCHAR(50),
	email VARCHAR(80),
	tipo_documento_id INT,
	tipo_tercero_id INT,
	ciudad_id INT,
	FOREIGN KEY (tipo_documento_id) REFERENCES tipo_documento(id),
	FOREIGN KEY (tipo_tercero_id) REFERENCES tipo_tercero(id),
	FOREIGN KEY (ciudad_id) REFERENCES ciudad(id)
);

CREATE TABLE tercero_telefono (
	id INT PRIMARY KEY,
	numero VARCHAR(20),
	tipo VARCHAR(50),
	tercero_id INT,
	FOREIGN KEY (tercero_id) REFERENCES tercero(id)
);

CREATE TABLE eps (
	id INT PRIMARY KEY,
	nombre VARCHAR(50)
);

CREATE TABLE arl (
	id INT PRIMARY KEY,
	nombre VARCHAR(50)
);

CREATE TABLE empleado (
	id INT PRIMARY KEY,
	tercero_id INT,
	fecha_ingreso DATE,
	salario_base DECIMAL(10,2),
	eps_id INT,
	arl_id INT,
	FOREIGN KEY (tercero_id) REFERENCES tercero(id),
	FOREIGN KEY (eps_id) REFERENCES eps(id),
	FOREIGN KEY (arl_id) REFERENCES arl(id)
);

CREATE TABLE proveedor (
	id INT PRIMARY KEY,
	tercero_id INT,
	documento VARCHAR(50),
	dia_pago INT,
	FOREIGN KEY (tercero_id) REFERENCES tercero(id)
);

CREATE TABLE cliente (
	id INT PRIMARY KEY,
	fecha_nacimiento DATE,
	fecha_compra DATE
);

CREATE TABLE producto (
	id INT PRIMARY KEY,
	nombre VARCHAR(50),
	stock INT,
	stock_minimo INT,
	stock_maximo INT,
	createdAt DATE,
	updatedAt DATE,
	bar_code VARCHAR(50)
);

CREATE TABLE producto_proveedor (
	tercero_id INT,
	producto_id INT,
	PRIMARY KEY (tercero_id, producto_id),
	FOREIGN KEY (tercero_id) REFERENCES tercero(id),
	FOREIGN KEY (producto_id) REFERENCES producto(id)
);

CREATE TABLE planes (
	id INT PRIMARY KEY,
	nombre VARCHAR(30),
	fecha_inicio DATE,
	fecha_fin DATE,
	documento VARCHAR(50)
);

CREATE TABLE plan_producto (
	plan_id INT,
	producto_id INT,
	PRIMARY KEY (plan_id, producto_id),
	FOREIGN KEY (plan_id) REFERENCES planes(id),
	FOREIGN KEY (producto_id) REFERENCES producto(id)
);

CREATE TABLE tipo_movimiento_caja (
	id INT PRIMARY KEY,
	nombre VARCHAR(50),
	tipo VARCHAR(50)
);

CREATE TABLE movimiento_caja (
	id INT PRIMARY KEY,
	fecha DATE,
	tipo_movimiento_id INT,
	valor DECIMAL(10,2),
	concepto VARCHAR(50),
	tercero_id INT,
	FOREIGN KEY (tipo_movimiento_id) REFERENCES tipo_movimiento_caja(id),
	FOREIGN KEY (tercero_id) REFERENCES tercero(id)
);

CREATE TABLE facturacion (
	id INT PRIMARY KEY,
	fecha_resolucion DATE,
	numInicio INT,
	numFinal INT,
	factura_actual VARCHAR(50)
);

CREATE TABLE venta (
	id INT PRIMARY KEY,
	factura_id INT,
	fecha DATE,
	empleado_id INT,
	cliente_id INT,
	FOREIGN KEY (factura_id) REFERENCES facturacion(id),
	FOREIGN KEY (empleado_id) REFERENCES empleado(id),
	FOREIGN KEY (cliente_id) REFERENCES cliente(id)
);

CREATE TABLE detalle_venta (
	id INT PRIMARY KEY,
	factura_id INT,
	producto_id INT,
	cantidad INT,
	valor DECIMAL(10,2),
	FOREIGN KEY (factura_id) REFERENCES facturacion(id),
	FOREIGN KEY (producto_id) REFERENCES producto(id)
);

CREATE TABLE compras (
	id INT PRIMARY KEY,
	proveedor_id INT,
	empleado_id INT,
	docCompra VARCHAR(50),
	fecha DATE,
	FOREIGN KEY (proveedor_id) REFERENCES proveedor(id),
	FOREIGN KEY (empleado_id) REFERENCES empleado(id)
);

CREATE TABLE detalle_compra (
	id INT PRIMARY KEY,
	fecha DATE,
	producto_id INT,
	cantidad INT,
	valor DECIMAL(10,2),
	compra_id INT,
	FOREIGN KEY (producto_id) REFERENCES producto(id),
	FOREIGN KEY (compra_id) REFERENCES compras(id)
);
