import { create } from "zustand";

interface CartItem {
  productId: string;
  quantity: number;
  name?: string;
  price?: number;
}

interface CartState {
  items: CartItem[];
  setCart: (items: CartItem[]) => void;
}

export const useCartStore = create<CartState>((set) => ({
  items: [],
  setCart: (items) => set({ items }),
}));