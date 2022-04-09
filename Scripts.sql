CREATE SCHEMA `permissionsdb` ;

CREATE TABLE `permissionsdb`.`permissions_type` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `description` VARCHAR(60) NOT NULL,
  PRIMARY KEY (`id`));

CREATE TABLE `permissionsdb`.`permissions` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `employee_name` VARCHAR(45) NOT NULL,
  `employee_last_name` VARCHAR(45) NOT NULL,
  `permissions_type_id` INT NOT NULL,
  `date` DATE NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `permissions_type_idx` (`permissions_type_id` ASC),
  CONSTRAINT `permissions_type`
    FOREIGN KEY (`permissions_type_id`)
    REFERENCES `permissionsdb`.`permisions_type` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
