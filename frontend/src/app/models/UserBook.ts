export class UserBook {
  id?: string = '';
  firstName: string = '';
  lastName: string = '';
  bookId: string = '';
  bookName: string = '';
  reserveDate: Date = new Date();
  expirationDate: Date = new Date();
}
