interface Contact {
  id: number;
  name: string;
  email: string;
  phone: string;
}

class ContactManager {
  private contacts: Contact[] = [];

  addContact(contact: Contact): void {
    this.contacts.push(contact);
    console.log(`Contact "${contact.name}" added successfully.`);
  }

  viewContacts(): Contact[] {
    if (this.contacts.length === 0) {
      console.log("No contacts found.");
    } else {
      console.log("All Contacts:");
      this.contacts.forEach(c => {
        console.log(`ID: ${c.id} | Name: ${c.name} | Email: ${c.email} | Phone: ${c.phone}`);
      });
    }
    return this.contacts;
  }

  modifyContact(id: number, updatedContact: Partial<Contact>): void {
    const index = this.contacts.findIndex(c => c.id === id);
    if (index === -1) {
      throw new Error(`Contact with ID ${id} does not exist.`);
    }
    this.contacts[index] = { ...this.contacts[index], ...updatedContact };
    console.log(`Contact with ID ${id} updated successfully.`);
  }

  deleteContact(id: number): void {
    const index = this.contacts.findIndex(c => c.id === id);
    if (index === -1) {
      throw new Error(`Contact with ID ${id} does not exist.`);
    }
    this.contacts.splice(index, 1);
    console.log(`Contact with ID ${id} deleted successfully.`);
  }
}

const manager = new ContactManager();

manager.addContact({ id: 1, name: "Naitik", email: "naitik@example.com", phone: "9876543210" });
manager.addContact({ id: 2, name: "Chinu", email: "chinu@example.com", phone: "9123456789" });
manager.addContact({ id: 3, name: "Kartik", email: "kartik@example.com", phone: "9001234567" });

manager.viewContacts();

manager.modifyContact(2, { phone: "9999999999" });

manager.viewContacts();

manager.deleteContact(3);

manager.viewContacts();

try {
  manager.modifyContact(99, { name: "Ghost" });
} catch (error: any) {
  console.log("Error:", error.message);
}

try {
  manager.deleteContact(99);
} catch (error: any) {
  console.log("Error:", error.message);
}