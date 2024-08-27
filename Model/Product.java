package Model;

import java.util.Objects;

public class Product {
    private int ID;
    private String name;
    private float buyPrice;
    private float salePrice;
    private int stock;
    private String description;

    public Product(int ID, String name, float buyPrice, float salePrice, int stock, String description) {
        this.ID = ID;
        this.name = name;
        this.buyPrice = buyPrice;
        this.salePrice = salePrice;
        this.stock = stock;
        this.description = description;
    }

    public Product(){
        this.ID = 0;
        this.name = "";
        this.buyPrice = 0;
        this.salePrice = 0;
        this.stock = 0;
        this.description = "";
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public float getBuyPrice() {
        return buyPrice;
    }

    public void setBuyPrice(float buyPrice) {
        this.buyPrice = buyPrice;
    }

    public float getSalePrice() {
        return salePrice;
    }

    public void setSalePrice(float salePrice) {
        this.salePrice = salePrice;
    }

    public int getStock() {
        return stock;
    }

    public void setStock(int stock) {
        this.stock = stock;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Product product)) return false;
        return ID == product.ID && Float.compare(buyPrice, product.buyPrice) == 0 && Float.compare(salePrice, product.salePrice) == 0 && stock == product.stock && Objects.equals(name, product.name) && Objects.equals(description, product.description);
    }

    @Override
    public int hashCode() {
        return Objects.hash(ID, name, buyPrice, salePrice, stock, description);
    }

    @Override
    public String toString() {
        return
                "ID = " + ID +
                ", Nombre = '" + name + '\'' +
                ", Precio de costo = " + buyPrice +
                ", Precio de venta = " + salePrice +
                ", Stock = " + stock +
                ", Descripción = '" + description + '\'' +
                '}';
    }
}
