--igotswag
 --qwerty
 --omgomgomg
  --noswag123
INSERT INTO User
VALUES ('matt', '71d4ac373d7bc27edb681ab883d3165d', 'Matt', 'Joy', '9876543210', 'Hostel Block 14', 'Manipal', 'Karnataka', '576104', 'mattjoy@gmail.com');
INSERT INTO User
VALUES ('abhi', 'd8578edf8458ce06fbc5bb76a58c5ca4', 'Abhi', 'Jeet', '1234567890', '123 Apple Street', 'Patna', 'Bihar', '132456', 'spaceman@gmail.com');
INSERT INTO User
VALUES ('ujj', 'aad9c39311c0de5f20790ee417d35630', 'Ujjwal', 'Arora', '9901339128', 'C-57', 'Malviya Nagar', 'New Delhi', '110017', 'arora.ujjwal@gmail.com');
INSERT INTO User
VALUES ('vin', '24f98bd436524b1ac89bd589b0261a81', 'Vinayak', 'Agarwal', '3534565742', '35 Orange Street', 'Azad Nagar', 'Kanpur', '208002', 'va6996@gmail.com');

--popat
 --1234
--p4ssw0rd

INSERT INTO FD_Employee
VALUES ('kev', 'bbdd77baecf8d8220953e3512311c56e', 'Kevin', 'Hoofstadder', 'Employee');
INSERT INTO FD_Employee
VALUES ('jess', '81dc9bdb52d04dc20036dbd8313ed055', 'Jessica', 'Cooper', 'Employee');
INSERT INTO FD_Employee
VALUES ('root', '2a9d119df47ff993b662a8ef36f9ea20', 'Hal', 'Machinima', 'Admin');

 --asdfg
  --killallhumans
    --killalien
INSERT INTO Manager
VALUES ('joe', '040b7cf4a55014e185813e0644502ea9', 'Joe', 'Fox');
INSERT INTO Manager
VALUES ('alien', '142c336c25b749d71cc669b466114a64', 'Monseur', 'Alien');
INSERT INTO Manager
VALUES ('predator', '4f2ce03a45a59dcffed585df17d8e189', 'Predator', 'One');

INSERT INTO Restaurant(m_id, name, phone, street, city, state, zip)
VALUES ('joe', 'Dollops', '9901356789', 'Tiger Circle', 'Manipal', 'Karnataka', '576104');
INSERT INTO Restaurant(m_id, name, phone, street, city, state, zip)
VALUES ('alien', 'Hangyo CTF', '9891234567', 'Syndicate Circle', 'Manipal', 'Karnataka', '576104');
INSERT INTO Restaurant(m_id, name, phone, street, city, state, zip)
VALUES ('predator', 'Dosa Point', '8778467235', 'Bus Stop', 'Udupi', 'Karnataka', '576225');

INSERT INTO PRODUCT(r_id, name, category, type, description, price)
VALUES (1, 'Butter Chicken', 'Main Course', 'Non-Veg', 'Sweet rich taste of authentic Punjabi chicken', 250);
INSERT INTO PRODUCT(r_id, name, category, type, description, price)
VALUES (1, 'Shahi Paneer', 'Main Course', 'Veg', 'Live like a king with Shahi Paneer', 200);
INSERT INTO PRODUCT(r_id, name, category, type, description, price)
VALUES (1, 'Aaaloo Parantha', 'Breads', 'Veg', 'Authentic Punjabi aaloo parantha', 50);
INSERT INTO PRODUCT(r_id, name, category, type, description, price)
VALUES (1, 'Butter Nan', 'Breads', 'Veg', 'Nan with butter on top', 30);
INSERT INTO PRODUCT(r_id, name, category, type, description, price)
VALUES (1, 'Dragon Chicken', 'Starters', 'Non-Veg', 'Straight from Shanghai', 150);
INSERT INTO PRODUCT(r_id, name, category, type, description, price)
VALUES (1, 'Death by Chocolate', 'Dessert', 'Veg', 'Chocolate that kills you', 90);
INSERT INTO PRODUCT(r_id, name, category, type, description, price)
VALUES (2, 'Belgian Chocolate', 'Dessert', 'Veg', 'Enjoy the very best icecream', 30);
INSERT INTO PRODUCT(r_id, name, category, type, description, price)
VALUES (2, 'Blueberry', 'Dessert', 'Veg', 'Enjoy the very best icecream', 30);

INSERT INTO Orders(u_id, fde_id, total_cost, delivery_type, status)
VALUES ('ujj', 'kev', 300, 'Delivery', 'Pending');
INSERT INTO Orders(u_id, fde_id, total_cost, delivery_type, status)
VALUES ('matt', 'kev', 150, 'Delivery', 'Pending');
INSERT INTO Orders(u_id, fde_id, total_cost, delivery_type, status)
VALUES ('ujj', 'kev', 350, 'Delivery', 'Delivered');
INSERT INTO Orders(u_id, fde_id, total_cost, delivery_type, status)
VALUES ('matt', 'kev', 100, 'Delivery', 'Delivered');
