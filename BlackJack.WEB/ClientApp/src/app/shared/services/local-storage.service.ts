import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService<T> {
  constructor() { }

  clear() {
    localStorage.clear();
  }

  removeItem(key: string) {
    localStorage.removeItem(key);
  }

  setItem(key: string, data: T): boolean {
    try {
      if (typeof data === "string") {
        localStorage.setItem(key, data)
      }
      else if (typeof data === "number" || typeof data === "boolean") {
        localStorage.setItem(key, data.toString())
      }
      else {
        localStorage.setItem(key, JSON.stringify(data));
      }
      return true;
    }
    catch (e) {
      return false;
    }
  }

  getItem(key: string): string {
    try {
      var data = localStorage.getItem(key);
      if (!data) return null; else
        return data;
    } catch (e) {
      console.log('Error getting data from localStorage', e);
      return null;
    }
  }
}
