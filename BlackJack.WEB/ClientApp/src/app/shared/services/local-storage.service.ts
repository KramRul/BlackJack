import { Injectable } from '@angular/core';
import { createDirectiveInstance } from '@angular/core/src/view/provider';

@Injectable({
  providedIn: 'root'
})

export class LocalStorageService {
  constructor() { }

  clear() {
    localStorage.clear();
  }

  removeItem(key: string) {
    localStorage.removeItem(key);
  }

  setItem<T>(key: string, data: T) {
    try {
      const dataAsString: string = (typeof data === "string") ? data : JSON.stringify(data);
      localStorage.setItem(key, dataAsString);
    }
    catch (e) {
      console.log('Error getting data from localStorage', e);
    }
  }

  getItem<T=string>(key: string, typeT: T): T {
    try {
      const dataAsString = localStorage.getItem(key);
      return (typeof typeT === "string") ? dataAsString : JSON.parse(dataAsString);         
    } catch (e) {
      console.log('Error getting data from localStorage', e);
      return null;
    }
  }
}
