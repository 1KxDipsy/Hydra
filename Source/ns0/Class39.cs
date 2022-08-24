using System;
using System.Globalization;
using System.IO;
using ns10;
using ns11;
using ns13;
using ns14;

namespace ns0
{
	internal sealed class Class39 : IDisposable
	{
		private static readonly string string_0;

		private static readonly string string_1;

		private static readonly string string_2;

		private static readonly string string_3;

		private static readonly string string_4;

		private static readonly string string_5;

		private static readonly string string_6;

		private static readonly string string_7;

		private static readonly string string_8;

		private readonly Class45 class45_0;

		private readonly HtmlContainerInt htmlContainerInt_0;

		private RContextMenu rcontextMenu_0;

		private RControl rcontrol_0;

		private Class59 class59_0;

		private Class50 class50_0;

		static Class39()
		{
			if (CultureInfo.CurrentUICulture.Name.StartsWith("fr", StringComparison.InvariantCultureIgnoreCase))
			{
				Class39.string_0 = "Tout sélectionner";
				Class39.string_1 = "Copier";
				Class39.string_2 = "Copier l'adresse du lien";
				Class39.string_3 = "Ouvrir le lien";
				Class39.string_4 = "Copier l'URL de l'image";
				Class39.string_5 = "Copier l'image";
				Class39.string_6 = "Enregistrer l'image sous...";
				Class39.string_7 = "Ouvrir la vidéo";
				Class39.string_8 = "Copier l'URL de l'vidéo";
			}
			else if (CultureInfo.CurrentUICulture.Name.StartsWith("de", StringComparison.InvariantCultureIgnoreCase))
			{
				Class39.string_0 = "Alle auswählen";
				Class39.string_1 = "Kopieren";
				Class39.string_2 = "Link-Adresse kopieren";
				Class39.string_3 = "Link öffnen";
				Class39.string_4 = "Bild-URL kopieren";
				Class39.string_5 = "Bild kopieren";
				Class39.string_6 = "Bild speichern unter...";
				Class39.string_7 = "Video öffnen";
				Class39.string_8 = "Video-URL kopieren";
			}
			else if (CultureInfo.CurrentUICulture.Name.StartsWith("it", StringComparison.InvariantCultureIgnoreCase))
			{
				Class39.string_0 = "Seleziona tutto";
				Class39.string_1 = "Copia";
				Class39.string_2 = "Copia indirizzo del link";
				Class39.string_3 = "Apri link";
				Class39.string_4 = "Copia URL immagine";
				Class39.string_5 = "Copia immagine";
				Class39.string_6 = "Salva immagine con nome...";
				Class39.string_7 = "Apri il video";
				Class39.string_8 = "Copia URL video";
			}
			else if (CultureInfo.CurrentUICulture.Name.StartsWith("es", StringComparison.InvariantCultureIgnoreCase))
			{
				Class39.string_0 = "Seleccionar todo";
				Class39.string_1 = "Copiar";
				Class39.string_2 = "Copiar dirección de enlace";
				Class39.string_3 = "Abrir enlace";
				Class39.string_4 = "Copiar URL de la imagen";
				Class39.string_5 = "Copiar imagen";
				Class39.string_6 = "Guardar imagen como...";
				Class39.string_7 = "Abrir video";
				Class39.string_8 = "Copiar URL de la video";
			}
			else if (CultureInfo.CurrentUICulture.Name.StartsWith("ru", StringComparison.InvariantCultureIgnoreCase))
			{
				Class39.string_0 = "Выбрать все";
				Class39.string_1 = "Копировать";
				Class39.string_2 = "Копировать адрес ссылки";
				Class39.string_3 = "Перейти по ссылке";
				Class39.string_4 = "Копировать адрес изображения";
				Class39.string_5 = "Копировать изображение";
				Class39.string_6 = "Сохранить изображение как...";
				Class39.string_7 = "Открыть видео";
				Class39.string_8 = "Копировать адрес видео";
			}
			else if (CultureInfo.CurrentUICulture.Name.StartsWith("sv", StringComparison.InvariantCultureIgnoreCase))
			{
				Class39.string_0 = "Välj allt";
				Class39.string_1 = "Kopiera";
				Class39.string_2 = "Kopiera länkadress";
				Class39.string_3 = "Öppna länk";
				Class39.string_4 = "Kopiera bildens URL";
				Class39.string_5 = "Kopiera bild";
				Class39.string_6 = "Spara bild som...";
				Class39.string_7 = "Öppna video";
				Class39.string_8 = "Kopiera video URL";
			}
			else if (CultureInfo.CurrentUICulture.Name.StartsWith("hu", StringComparison.InvariantCultureIgnoreCase))
			{
				Class39.string_0 = "Összes kiválasztása";
				Class39.string_1 = "Másolás";
				Class39.string_2 = "Hivatkozás címének másolása";
				Class39.string_3 = "Hivatkozás megnyitása";
				Class39.string_4 = "Kép URL másolása";
				Class39.string_5 = "Kép másolása";
				Class39.string_6 = "Kép mentése másként...";
				Class39.string_7 = "Videó megnyitása";
				Class39.string_8 = "Videó URL másolása";
			}
			else if (CultureInfo.CurrentUICulture.Name.StartsWith("cs", StringComparison.InvariantCultureIgnoreCase))
			{
				Class39.string_0 = "Vybrat vše";
				Class39.string_1 = "Kopírovat";
				Class39.string_2 = "Kopírovat adresu odkazu";
				Class39.string_3 = "Otevřít odkaz";
				Class39.string_4 = "Kopírovat URL snímku";
				Class39.string_5 = "Kopírovat snímek";
				Class39.string_6 = "Uložit snímek jako...";
				Class39.string_7 = "Otevřít video";
				Class39.string_8 = "Kopírovat URL video";
			}
			else if (CultureInfo.CurrentUICulture.Name.StartsWith("da", StringComparison.InvariantCultureIgnoreCase))
			{
				Class39.string_0 = "Vælg alt";
				Class39.string_1 = "Kopiér";
				Class39.string_2 = "Kopier link-adresse";
				Class39.string_3 = "Åbn link";
				Class39.string_4 = "Kopier billede-URL";
				Class39.string_5 = "Kopier billede";
				Class39.string_6 = "Gem billede som...";
				Class39.string_7 = "Åbn video";
				Class39.string_8 = "Kopier video-URL";
			}
			else if (CultureInfo.CurrentUICulture.Name.StartsWith("nl", StringComparison.InvariantCultureIgnoreCase))
			{
				Class39.string_0 = "Alles selecteren";
				Class39.string_1 = "Kopiëren";
				Class39.string_2 = "Link adres kopiëren";
				Class39.string_3 = "Link openen";
				Class39.string_4 = "URL Afbeelding kopiëren";
				Class39.string_5 = "Afbeelding kopiëren";
				Class39.string_6 = "Bewaar afbeelding als...";
				Class39.string_7 = "Video openen";
				Class39.string_8 = "URL video kopiëren";
			}
			else if (CultureInfo.CurrentUICulture.Name.StartsWith("fi", StringComparison.InvariantCultureIgnoreCase))
			{
				Class39.string_0 = "Valitse kaikki";
				Class39.string_1 = "Kopioi";
				Class39.string_2 = "Kopioi linkin osoite";
				Class39.string_3 = "Avaa linkki";
				Class39.string_4 = "Kopioi kuvan URL";
				Class39.string_5 = "Kopioi kuva";
				Class39.string_6 = "Tallena kuva nimellä...";
				Class39.string_7 = "Avaa video";
				Class39.string_8 = "Kopioi video URL";
			}
			else
			{
				Class39.string_0 = "Select all";
				Class39.string_1 = "Copy";
				Class39.string_2 = "Copy link address";
				Class39.string_3 = "Open link";
				Class39.string_4 = "Copy image URL";
				Class39.string_5 = "Copy image";
				Class39.string_6 = "Save image as...";
				Class39.string_7 = "Open video";
				Class39.string_8 = "Copy video URL";
			}
		}

		public Class39(Class45 class45_1, HtmlContainerInt htmlContainerInt_1)
		{
			ArgChecker.AssertArgNotNull(class45_1, "selectionHandler");
			ArgChecker.AssertArgNotNull(htmlContainerInt_1, "htmlContainer");
			this.class45_0 = class45_1;
			this.htmlContainerInt_0 = htmlContainerInt_1;
		}

		public void method_0(RControl rcontrol_1, Class59 class59_1, Class50 class50_1)
		{
			try
			{
				this.method_1();
				this.rcontrol_0 = rcontrol_1;
				this.class59_0 = class59_1;
				this.class50_0 = class50_1;
				this.rcontextMenu_0 = this.htmlContainerInt_0.RAdapter_0.GetContextMenu();
				if (class59_1 != null)
				{
					bool flag = false;
					if (class50_1 != null)
					{
						flag = class50_1 is Class51 && ((Class51)class50_1).Boolean_6;
						bool enabled = !string.IsNullOrEmpty(class50_1.String_65);
						this.rcontextMenu_0.AddItem(flag ? Class39.string_7 : Class39.string_3, enabled, new EventHandler(method_2));
						if (this.htmlContainerInt_0.IsSelectionEnabled)
						{
							this.rcontextMenu_0.AddItem(flag ? Class39.string_8 : Class39.string_2, enabled, new EventHandler(method_3));
						}
						this.rcontextMenu_0.AddDivider();
					}
					if (class59_1.Boolean_3 && !flag)
					{
						this.rcontextMenu_0.AddItem(Class39.string_6, class59_1.RImage_0 != null, new EventHandler(method_4));
						if (this.htmlContainerInt_0.IsSelectionEnabled)
						{
							this.rcontextMenu_0.AddItem(Class39.string_4, !string.IsNullOrEmpty(this.class59_0.Class50_0.method_13("src")), new EventHandler(method_5));
							this.rcontextMenu_0.AddItem(Class39.string_5, class59_1.RImage_0 != null, new EventHandler(method_6));
						}
						this.rcontextMenu_0.AddDivider();
					}
					if (this.htmlContainerInt_0.IsSelectionEnabled)
					{
						this.rcontextMenu_0.AddItem(Class39.string_1, class59_1.Boolean_0, new EventHandler(method_7));
					}
				}
				if (this.htmlContainerInt_0.IsSelectionEnabled)
				{
					this.rcontextMenu_0.AddItem(Class39.string_0, enabled: true, new EventHandler(method_8));
				}
				if (this.rcontextMenu_0.ItemsCount > 0)
				{
					this.rcontextMenu_0.RemoveLastDivider();
					this.rcontextMenu_0.Show(rcontrol_1, rcontrol_1.MouseLocation);
				}
			}
			catch (Exception exception_)
			{
				this.htmlContainerInt_0.method_2(HtmlRenderErrorType.ContextMenu, "Failed to show context menu", exception_);
			}
		}

		public void Dispose()
		{
			this.method_1();
		}

		private void method_1()
		{
			try
			{
				if (this.rcontextMenu_0 != null)
				{
					this.rcontextMenu_0.Dispose();
				}
				this.rcontextMenu_0 = null;
				this.rcontrol_0 = null;
				this.class59_0 = null;
				this.class50_0 = null;
			}
			catch
			{
			}
		}

		private void method_2(object sender, EventArgs e)
		{
			try
			{
				this.class50_0.HtmlContainerInt_0.method_3(this.rcontrol_0, this.rcontrol_0.MouseLocation, this.class50_0);
			}
			catch (HtmlLinkClickedException)
			{
				throw;
			}
			catch (Exception exception_)
			{
				this.htmlContainerInt_0.method_2(HtmlRenderErrorType.ContextMenu, "Failed to open link", exception_);
			}
			finally
			{
				this.method_1();
			}
		}

		private void method_3(object sender, EventArgs e)
		{
			try
			{
				this.htmlContainerInt_0.RAdapter_0.SetToClipboard(this.class50_0.String_65);
			}
			catch (Exception exception_)
			{
				this.htmlContainerInt_0.method_2(HtmlRenderErrorType.ContextMenu, "Failed to copy link url to clipboard", exception_);
			}
			finally
			{
				this.method_1();
			}
		}

		private void method_4(object sender, EventArgs e)
		{
			try
			{
				string path = this.class59_0.Class50_0.method_13("src");
				this.htmlContainerInt_0.RAdapter_0.SaveToFile(this.class59_0.RImage_0, Path.GetFileName(path) ?? "image", Path.GetExtension(path) ?? "png");
			}
			catch (Exception exception_)
			{
				this.htmlContainerInt_0.method_2(HtmlRenderErrorType.ContextMenu, "Failed to save image", exception_);
			}
			finally
			{
				this.method_1();
			}
		}

		private void method_5(object sender, EventArgs e)
		{
			try
			{
				this.htmlContainerInt_0.RAdapter_0.SetToClipboard(this.class59_0.Class50_0.method_13("src"));
			}
			catch (Exception exception_)
			{
				this.htmlContainerInt_0.method_2(HtmlRenderErrorType.ContextMenu, "Failed to copy image url to clipboard", exception_);
			}
			finally
			{
				this.method_1();
			}
		}

		private void method_6(object sender, EventArgs e)
		{
			try
			{
				this.htmlContainerInt_0.RAdapter_0.SetToClipboard(this.class59_0.RImage_0);
			}
			catch (Exception exception_)
			{
				this.htmlContainerInt_0.method_2(HtmlRenderErrorType.ContextMenu, "Failed to copy image to clipboard", exception_);
			}
			finally
			{
				this.method_1();
			}
		}

		private void method_7(object sender, EventArgs e)
		{
			try
			{
				this.class45_0.method_6();
			}
			catch (Exception exception_)
			{
				this.htmlContainerInt_0.method_2(HtmlRenderErrorType.ContextMenu, "Failed to copy text to clipboard", exception_);
			}
			finally
			{
				this.method_1();
			}
		}

		private void method_8(object sender, EventArgs e)
		{
			try
			{
				this.class45_0.method_0(this.rcontrol_0);
			}
			catch (Exception exception_)
			{
				this.htmlContainerInt_0.method_2(HtmlRenderErrorType.ContextMenu, "Failed to select all text", exception_);
			}
			finally
			{
				this.method_1();
			}
		}
	}
}
