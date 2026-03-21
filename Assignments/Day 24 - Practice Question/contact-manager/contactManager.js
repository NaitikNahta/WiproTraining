var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
var ContactManager = /** @class */ (function () {
    function ContactManager() {
        this.contacts = [];
    }
    ContactManager.prototype.addContact = function (contact) {
        this.contacts.push(contact);
        console.log("Contact \"".concat(contact.name, "\" added successfully."));
    };
    ContactManager.prototype.viewContacts = function () {
        if (this.contacts.length === 0) {
            console.log("No contacts found.");
        }
        else {
            console.log("All Contacts:");
            this.contacts.forEach(function (c) {
                console.log("ID: ".concat(c.id, " | Name: ").concat(c.name, " | Email: ").concat(c.email, " | Phone: ").concat(c.phone));
            });
        }
        return this.contacts;
    };
    ContactManager.prototype.modifyContact = function (id, updatedContact) {
        var index = this.contacts.findIndex(function (c) { return c.id === id; });
        if (index === -1) {
            throw new Error("Contact with ID ".concat(id, " does not exist."));
        }
        this.contacts[index] = __assign(__assign({}, this.contacts[index]), updatedContact);
        console.log("Contact with ID ".concat(id, " updated successfully."));
    };
    ContactManager.prototype.deleteContact = function (id) {
        var index = this.contacts.findIndex(function (c) { return c.id === id; });
        if (index === -1) {
            throw new Error("Contact with ID ".concat(id, " does not exist."));
        }
        this.contacts.splice(index, 1);
        console.log("Contact with ID ".concat(id, " deleted successfully."));
    };
    return ContactManager;
}());
var manager = new ContactManager();
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
}
catch (error) {
    console.log("Error:", error.message);
}
try {
    manager.deleteContact(99);
}
catch (error) {
    console.log("Error:", error.message);
}
