import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root', // Hace que el servicio esté disponible globalmente
})
export class CartService {
    private static cartKey = 'cart'; // Clave para almacenar el carrito en localStorage

    // Recuperar carrito por ID
    static getById(cartId: string): Cart {
        const cartData = localStorage.getItem(this.cartKey);
        if (cartData) {
            const cart = JSON.parse(cartData) as Cart;
            return cart.id === cartId ? cart : null;
        }
        return null;
    }

    // Crear un nuevo carrito
    static insert(): Cart {
        const newCart: Cart = {
            id: this.generateId(),
            items: [],
        };
        localStorage.setItem(this.cartKey, JSON.stringify(newCart));
        return newCart;
    }

    // Obtener los productos del carrito
    static getCartItems(cartId: string): CartItem[] {
        const cart = this.getById(cartId);
        return cart ? cart.items : [];
    }

    // Actualizar un producto en el carrito
    static updateItem(updatedItem: CartItem): void {
        const cartData = localStorage.getItem(this.cartKey);
        if (cartData) {
            const cart = JSON.parse(cartData) as Cart;
            const itemIndex = cart.items.findIndex(
                (item) => item.productId === updatedItem.productId
            );
            if (itemIndex > -1) {
                cart.items[itemIndex] = updatedItem;
                localStorage.setItem(this.cartKey, JSON.stringify(cart));
            }
        }
    }

    // Insertar un nuevo producto en el carrito
    static insertItem(newItem: CartItem): void {
        const cartData = localStorage.getItem(this.cartKey);
        if (cartData) {
            const cart = JSON.parse(cartData) as Cart;
            cart.items.push(newItem);
            localStorage.setItem(this.cartKey, JSON.stringify(cart));
        }
    }

    // Generar un ID único para el carrito
    private static generateId(): string {
        return Math.random().toString(36).substr(2, 9);
    }
}

// Interfaces
export interface Cart {
    id: string;
    items: CartItem[];
}

export interface CartItem {
    cartId: string;
    productId: string;
    quantity: number;
}

export interface Product {
    id: string;
    name: string;
    price: number;
}
