import { Injectable } from '@angular/core';

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

  setItem<T>(key: string, data: T): boolean {
    try {
      const dataAsString: string = (typeof data === "string") ? data : JSON.stringify(data);
      localStorage.setItem(key, dataAsString);
      return true;
    }
    catch (e) {
      return false;
    }
  }

  getItem<T>(key: string): string {
    try {
      var data = localStorage.getItem(key);
      return (!data) ? null : data;
    } catch (e) {
      console.log('Error getting data from localStorage', e);
      return null;
    }
  }
}
