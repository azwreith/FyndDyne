CREATE TABLE Manager (
  m_id VARCHAR(30),
  password VARCHAR(30) NOT NULL,
  f_name VARCHAR(30) NOT NULL,
  l_name VARCHAR(30) NOT NULL,
  PRIMARY KEY(m_id)
);

CREATE TABLE Restaurant (
  r_id INT AUTO_INCREMENT,
  m_id VARCHAR(30) UNIQUE,
  name VARCHAR(30) NOT NULL,
  phone VARCHAR(10) NOT NULL,
  street VARCHAR(30) NOT NULL,
  city VARCHAR(30) NOT NULL,
  state VARCHAR(30) NOT NULL,
  zip VARCHAR(6) NOT NULL,
  image LONGBLOB,
  PRIMARY KEY(r_id),
  FOREIGN KEY(m_id) REFERENCES Manager
);

CREATE TABLE FD_Employee (
  fde_id VARCHAR(30),
  password VARCHAR(30) NOT NULL,
  f_name VARCHAR(30) NOT NULL,
  l_name VARCHAR(30) NOT NULL,
  user_level ENUM('Admin', 'Employee') NOT NULL,
  PRIMARY KEY(fde_id)
);

CREATE TABLE User (
  u_id VARCHAR(30),
  password VARCHAR(30) NOT NULL,
  f_name VARCHAR(30) NOT NULL,
  l_name VARCHAR(30) NOT NULL,
  phone VARCHAR(10) NOT NULL,
  street VARCHAR(30) NOT NULL,
  city VARCHAR(30) NOT NULL,
  state VARCHAR(30) NOT NULL,
  zip VARCHAR(6) NOT NULL,
  email VARCHAR(30) NOT NULL,
  PRIMARY KEY(u_id)
);

CREATE TABLE Product (
  p_id INT AUTO_INCREMENT,
  r_id INT,
  name VARCHAR(30),
  category VARCHAR(30),
  type ENUM('Veg', 'Non-Veg'),
  description VARCHAR(200),
  price NUMERIC(10, 2),
  image LONGBLOB,
  PRIMARY KEY(p_id),
  FOREIGN KEY(r_id) REFERENCES Restaurant
);

CREATE TABLE Order (
  o_id INT AUTO_INCREMENT,
  u_id VARCHAR(30),
  fde_id VARCHAR(30),
  total_cost NUMERIC(10, 2),
  delivery_type ENUM('Takeaway', 'Delivery'),
  status ENUM('Pending', 'Delivered', 'Cancelled'),
  PRIMARY KEY(o_id),
  FOREIGN KEY(u_id) REFERENCES User,
  FOREIGN KEY(fde_id) REFERENCES FD_Employee
);

CREATE TABLE Order_Product (
  o_id INT,
  p_id INT,
  qty INT,
  PRIMARY KEY(o_id, p_id),
  FOREIGN KEY(o_id) REFERENCES Order,
  FOREIGN KEY(p_id) REFERENCES Product,
);
