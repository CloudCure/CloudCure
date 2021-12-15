import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserProfile } from '../AngularModels/UserProfile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(http: HttpClient) { }

  getProfile() : UserProfile | null{
    return null;
  }
}